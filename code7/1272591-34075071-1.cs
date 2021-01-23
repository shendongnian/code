    var first = new List<string> { "a" };
    var second = new List<ChangesSummary>()
    {
        new ChangesSummary() { ProviderKey = "a" },
        new ChangesSummary() { ProviderKey = "b" }
    };
    var result = second.Where(item => !first.Contains(item.ProviderKey));
        
    // result
    //    .ToList()
    //    .ForEach(item => Console.WriteLine(item.ProviderKey));
