    void Main()
    {
        var settings = new ConnectionSettings(new Uri("http://localhost:9200"));
    
        var client = new ElasticClient(settings);
    	var results = client.Search<DataRecord>(s => s
    	   .Index("index")
    	   .Aggregations(DateHistogramOfAveragesForFields("mydoc", new[] { "channel1", "channel2", "channel3", "channel4" })
    	   )
       );
    
    	Console.WriteLine(string.Format("{0} {1}", results.RequestInformation.RequestMethod, results.RequestInformation.RequestUrl));
    	Console.WriteLine(Encoding.UTF8.GetString(results.RequestInformation.Request));
    }
    
    public class DataRecord { }
