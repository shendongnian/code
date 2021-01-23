        // change the default camelcase property name serialization 
        // behaviour with .SetDefaultPropertyNameInferrer
        var settings = new ConnectionSettings(new Uri("http://localhost:9200"))
            .SetDefaultPropertyNameInferrer(s => s);
        var client = new ElasticClient(settings);
    		
        var r = client.Search<poc>(s => s
                    .Index("gl_search")
                    .From(0)
                    .Size(10)
                    .Query(q => q
                       .Term(p => p.Account_No, "056109")
    				)
                );
