    var strings = new string[] { "a", "a", "b", "b", "b", "c" };
    var mostPopular = strings
        .GroupBy(s => s) //removed unnecessary count
        .OrderByDescending(g => g.Count());
    mostPopular.ToList().ForEach(g => Console.WriteLine("{0}: {1}", g.Key, g.Count()));
