    void Main()
    {
        var settings = new ConnectionSettings(new Uri("http://localhost:9200"));
        var connection = new InMemoryConnection(settings);
        var client = new ElasticClient(connection: connection);
    		
    	DateTime? from = new DateTime(2015, 2,1);
    	DateTime? to = new DateTime(2015, 2, 24);
    		
        var docs = client.Search<LogInfoIndexView>(s => s
    	    .Size(0)
    	    .Type("type")
    		.Aggregations(a => a
    			.Filter("log_query", f => f
    				.Filter(ff => ff
    					.Bool(b => b
    						.Must(m => m
    							.Term(t => t.Cluster, "giauht1"),
    							  m => m
    							.Term(t => t.Server, "hadoop0"),
    							  m => m
    							.Term(t => t.Type, "Warn"),
    							  m => m
    							.Range(r => r.OnField("actionTime").GreaterOrEquals(from.Value).LowerOrEquals(to.Value))
    						)
    					)
    			    )
    				.Aggregations(aa => aa
    					.DateHistogram("histogram_Log", da => da
    						.Field("actionTime")
    						.Interval("1d")
    						.Format("dd/MM/YYYY hh:mm:ss")
    				    )
    				)
    		    )
    	    )
    	);
    			
    	Console.WriteLine(Encoding.UTF8.GetString(docs.RequestInformation.Request));
    }
    
    public class LogInfoIndexView
    {
    	public string Cluster { get; set; }
    	public string Server { get; set; }
    	public string Type { get; set; }
    	public DateTime ActionTime { get; set; }	
    }
