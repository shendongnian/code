    void Main()
    {
        var settings = new ConnectionSettings(new Uri("http://localhost:9200"));
        var connection = new InMemoryConnection(settings);
        var client = new ElasticClient(connection: connection);
    
    	var docs = client.Count<dynamic>(c => c
    		.Query(q => q
    			.Filtered(f1 => f1
    				.Filter(f2 => f2
    					.Bool(b => b
    						.Must(
    							f => f.Term(FieldName.AccountID, "10")
    						)
    						.Should(s => s
    							.Bool(b1 => b1
    								.Must(
    									f => f.Term(FieldName.PublishStatusID, "3"),
    									f => f.Range(m => m.OnField(FieldName.ScheduleDT).GreaterOrEquals("2015-09-01"))
    								)
    							),
    								s => s
    							.Bool(b1 => b1
    								.Must(
    									f => f.Term(FieldName.PublishStatusID, "4"),
    									f => f.Range(m => m.OnField(FieldName.PublishedDT).GreaterOrEquals("2015-09-01"))
    								)
    							)
    						)
    					)
    				)
    			)
    		)
    	);
    
        Console.WriteLine(Encoding.UTF8.GetString(docs.RequestInformation.Request));
    }
    
    public static class FieldName
    {
    	public static string AccountID = "AccountID";
    	public static string ScheduleDT = "ScheduleDT";
    	public static string PublishedDT = "PublishedDT";
    	public static string PublishStatusID = "PublishStatusID";
    }
