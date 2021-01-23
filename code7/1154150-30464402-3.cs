    var results = Tables.GroupBy(t => t.Status)
        .ToDictionary(g => g.Key, g => g.Count());
    foreach(var status in new[] {"Unoccupied", "Occupied"})
    {
        int count;
        results.TryGetValue(status, out count);
        Console.WriteLine("You have {0} tables of status {1}", count, status);
    }
