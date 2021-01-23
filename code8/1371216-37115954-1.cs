    List<object> objectToIndex = new List<object>(); // assume 3000 items here
    ElasticClient client = new ElasticClient(settings);
    client.IndexMany(objectsToIndex, indexName, type);
    
    // Do the refresh and wait
    client.Refresh();
    System.Threading.Thread.Sleep(1000);
    
    var readResult = client.Search<T>(e => e
        .Type(type)
        .Index(indexName)
        .Query(q => q
            .Range(r => r.OnField(t => t.Date).GreaterOrEquals(dates[0]).LowerOrEquals(dates[1]))
        )
    );
    // readResult SHOULD contain all 3000 files
