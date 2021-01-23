    var SearchAggregate = client.Search<string>(sd => sd
                        .Index("Index")
                        .Type("Table")
                        .Size(0)
                        .Query(q => q
                            .Bool(b => b
                                .Must(
                                    m => m.Terms("QID", new[] { strDouble.tostring() }),
                                    m => m.Terms("ProjectID", new[] { "50" }),
                                    m => m.Terms("RespID", arrRespId)                                    
                                    )))));
