    foreach (var entry in query)
    {
        Console.WriteLine("Athelet: {0}", entry.Athelet);
        foreach (Team t in entry.Teams)
        {
            Console.WriteLine("Team: {0}", t);
        }
    }
