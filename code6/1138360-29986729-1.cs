    var counts = filesZ
        .SelectMany(i => System.IO.File.ReadAllLines(i)
            .SelectMany(line => line.Split(new[] { ' ', ',', '.', '?', '!', '.' })
            .Distinct())
        .GroupBy(word => word)
        .ToDictionary(g => g.Key, g => g.Count());
