    foreach (var entry in query)
    {
        Console.WriteLine("Athlete: {0}", entry.Athlete);
        foreach (Team t in entry.Teams)
        {
            Console.WriteLine("Team: {0}", t);
        }
    }
