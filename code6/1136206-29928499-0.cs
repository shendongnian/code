    List<string> AverageList = new List<string> { "matt,5", "matt,7", "jack,4", "jack,8" };
    var query = AverageList.Select(s => s.Split(','))
        .GroupBy(sp => sp[0])
        .Select(grp =>
            new
            {
                Name = grp.Key,
                Avg = grp.Average(t=> int.Parse(t[1])),
            });
    foreach (var item in query)
    {
        Console.WriteLine("Name: {0}, Avg: {1}", item.Name, item.Avg);
    }
