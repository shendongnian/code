    var Filter = new List<string> { "field1", "field2" };
    var Value = new List<string> { "value1", "value2" };
    
    var fc = new List<FilterContainer>();
    for (int i = 0; i < 2 /* Size of Filter/Value list */; ++i)
    {
        fc.Add(Filter<string>.Term(Filter[i], Value[i]));
    }
    
    var searchResults = client.Search<Job>(s => s
        .Type("job")
        .Size(size)
        .Filter(f => f
            .Bool(b => b
                .Should(fc.ToArray()))));
