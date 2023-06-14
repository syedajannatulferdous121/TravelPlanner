using System;
using System.Collections.Generic;

class Destination
{
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public decimal Budget { get; set; }
    public List<string> Activities { get; set; }

    public Destination()
    {
        Activities = new List<string>();
    }
}

class TravelPlanner
{
    private List<Destination> destinations;

    public TravelPlanner()
    {
        destinations = new List<Destination>();
    }

    public void AddDestination(string name, DateTime date, decimal budget)
    {
        Destination destination = new Destination
        {
            Name = name,
            Date = date,
            Budget = budget
        };

        destinations.Add(destination);
        Console.WriteLine($"{name} added to your travel itinerary.");
    }

    public void AddActivity(string name, string activity)
    {
        Destination destination = destinations.Find(d => d.Name.ToLower() == name.ToLower());

        if (destination != null)
        {
            destination.Activities.Add(activity);
            Console.WriteLine($"{activity} added to {name} activities.");
        }
        else
        {
            Console.WriteLine($"{name} not found in your travel itinerary.");
        }
    }

    public void ViewDestinations()
    {
        Console.WriteLine("Your Travel Destinations:");
        foreach (Destination destination in destinations)
        {
            Console.WriteLine($"Name: {destination.Name} | Date: {destination.Date.ToString("dd MMM yyyy")} | Budget: {destination.Budget:C}");
            Console.WriteLine("Activities:");
            foreach (string activity in destination.Activities)
            {
                Console.WriteLine($"- {activity}");
            }
            Console.WriteLine();
        }
    }

    public void ClearDestinations()
    {
        destinations.Clear();
        Console.WriteLine("All destinations cleared from your travel itinerary.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        TravelPlanner planner = new TravelPlanner();

        Console.WriteLine("Welcome to Travel Planner!");
        Console.WriteLine("You can add, view, or clear your travel destinations.");

        while (true)
        {
            Console.WriteLine("\nChoose an action:");
            Console.WriteLine("1. Add Destination");
            Console.WriteLine("2. Add Activity");
            Console.WriteLine("3. View Destinations");
            Console.WriteLine("4. Clear Destinations");
            Console.WriteLine("5. Exit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter the destination name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter the date (dd/mm/yyyy): ");
                    DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
                    Console.Write("Enter the budget: ");
                    decimal budget = decimal.Parse(Console.ReadLine());
                    planner.AddDestination(name, date, budget);
                    break;
                case "2":
                    Console.Write("Enter the destination name: ");
                    string destName = Console.ReadLine();
                    Console.Write("Enter the activity: ");
                    string activity = Console.ReadLine();
                    planner.AddActivity(destName, activity);
                    break;
                case "3":
                    planner.ViewDestinations();
                    break;
                case "4":
                    planner.ClearDestinations();
                    break;
                case "5":
                    Console.WriteLine("Thank you for using Travel Planner. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
