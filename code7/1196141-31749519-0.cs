    var boostValues = new Dictionary<string, double>
    {
        { "kit", 3 },
        { "motor", 2.05 },
        { "fuel", 1.35 }
    };
    
    var qc = new List<QueryContainer>();
    foreach (var term in boostValues)
    {
        qc.Add(
            Query<Document>.Match(m => m
                .OnField(p => p.File)
                .Boost(term.Value)
                .Query(term.Key)));
    }
    
    var searchResults = client.Search<Document>(s => s
        .Index(defaultIndex)
        .Query(q => q
            .Bool(b => b
                .Should(qc.ToArray()))));
