    void Main()
    {
        var settings = new ConnectionSettings(new Uri("http://localhost:9200"));
        var connection = new InMemoryConnection(settings);
        var client = new ElasticClient(connection: connection);
    		
        var r = client.Search<poc>(s => s
                    .Index("gl_search")
                    .From(0)
                    .Size(10)
                    .Query(q => q
                       .Term(p => p.Account_No, "056109")
    				)
                );
        Console.WriteLine(Encoding.UTF8.GetString(r.RequestInformation.Request));
    }
