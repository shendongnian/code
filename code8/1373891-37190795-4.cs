    var allIds = parent
        .SelectMany(p => new[] { new { Type="Parent", p.Id, Parent = (int?)null } }
            .Concat(p.C1.Select(c => new { Type = "Child1", c.Id, Parent = (int?)p.Id }))
            .Concat(p.C2.Select(c => new { Type = "Child2", c.Id, Parent = (int?)p.Id })))
        .ToList();
    foreach (var x in allIds)
        Console.WriteLine("ID:{0} Type:{1} Parent-ID:{2}", x.Id, x.Type, x.Parent?.ToString() ?? "no parent");
