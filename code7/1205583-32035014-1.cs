    IDictionary<string, int> subjectCount = students
        .SelectMany(s => s.Subject.Split(','))
        .Select(s => s.Trim())
        .GroupBy(s => s)
        .ToDictionary(grp => grp.Key, grp => grp.Count());
    
    foreach (var count in subjectCount)
    {
        Console.WriteLine("{0}: {1}", count.Key, count.Value);
    }
