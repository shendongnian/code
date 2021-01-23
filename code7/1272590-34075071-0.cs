    var first = new List<string> { "a" };
    var second = new List<ChangesSummary>()
    {
        new ChangesSummary() { ProviderKey = "a" },
        new ChangesSummary() { ProviderKey = "b" }
    };
    second.Where(item => !first.Contains(item.ProviderKey))
        .ToList()
        .ForEach(item => Console.WriteLine(item.ProviderKey));
