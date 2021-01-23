    var merged = new List<Item>(items1);
    merged.AddRange(items2);
    IEnumerable<Item> grouped = merged
        .GroupBy((item) => new { item.Country, item.State, item.City, item.date })
        .Select((item) => item.OrderByDescending(i => i.population).FirstOrDefault());
    foreach(Item item in grouped)
    {
        Console.WriteLine($"{item.Country}, {item.State}, {item.City}, {item.date}, {item.population}");
    }
