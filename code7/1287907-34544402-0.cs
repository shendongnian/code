    var client = new ElasticClient(new ConnectionSettings(new Uri("http://localhost:9200")));
    
    var response = client.Map<object>(d => d
        .Index("songs")
        .Type("song")
        .Properties(props => props
            .String(s => s
                .Name("name"))
            .Completion(c => c
                .Name("suggest")
                .IndexAnalyzer("simple")
                .SearchAnalyzer("simple")
                .Payloads())));
    
    Debug.Assert(response.IsValid);
