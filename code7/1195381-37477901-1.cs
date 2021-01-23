    .GroupBy(x => string.Join("|", x.IDS))
    .Select(x => new 
                 {
                      IDS = x.Key.Split('|').Where(s => s != string.Empty).ToArray(),
                      Count = x.Count()
                 });
