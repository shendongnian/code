    var tableA = new List<TableA> { new TableA { Name = "1", Description = "D1" }, new TableA { Name = "2", Description = "D2"} };
    var tableB = new List<TableB> { new TableB { Name = "1", Value = "V1" }, new TableB { Name = "1", Value = "V2"} };
    var result = tableA.Join(tableB, a => a.Name, b => b.Name, (a, b) => new { A = a, B = b})
        .GroupBy(k => k.A, e => e.B.Value)
        .Select(g => new MyObject
        {
            Name = g.Key.Name,
            Description = g.Key.Description,
            Values = g.ToList()
        });
    foreach (var res in result)
    {
        Console.WriteLine("Name: {0}, Description: {1}, Value: {2}", res.Name, res.Description, string.Join(", ", res.Values));
    }
