    result.ToList().ForEach(group =>
    {
        Console.WriteLine(group.Key); // The date
        group.ToList().ForEach(entry => Console.WriteLine(entry.ID + " - " + entry.Agent)); // Print out each entry per group
    });
