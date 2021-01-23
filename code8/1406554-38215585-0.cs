    void Main()
    {
    	var settings = new ConnectionSettings(new Uri("http://localhost:9200"))
    		.ExposeRawResponse(true)
    		.PrettyJson()
    		.SetDefaultIndex("myIndexName")
    		.MapDefaultTypeNames(d => d.Add(typeof(myPoco), string.Empty))
    		.SetConnectionStatusHandler(r =>
    		{
    			// log out the requests
    			if (r.Request != null)
    			{
    				Console.WriteLine("{0} {1} \n{2}\n", r.RequestMethod.ToUpperInvariant(), r.RequestUrl,
    					Encoding.UTF8.GetString(r.Request));
    			}
    			else
    			{
    				Console.WriteLine("{0} {1}\n", r.RequestMethod.ToUpperInvariant(), r.RequestUrl);
    			}
                
                Console.WriteLine();
    
    			if (r.ResponseRaw != null)
    			{
    				Console.WriteLine("Status: {0}\n{1}\n\n{2}\n", r.HttpStatusCode, Encoding.UTF8.GetString(r.ResponseRaw), new String('-', 30));
    			}
    			else
    			{
    				Console.WriteLine("Status: {0}\n\n{1}\n", r.HttpStatusCode, new String('-', 30));
    			}
    		});
    
    	var client = new ElasticClient(settings, new InMemoryConnection());
    
    	int skipCount = 0;
    	int takeSize = 100;
    
    	var searchResults = client.Search<myPoco>(x => x
    		.Query(q => q
    		.Bool(b => b
    		.Must(m =>
    			m.Match(mt1 => mt1.OnField(f1 => f1.status).Query("New")))))
    		.Skip(skipCount)
    		.Take(takeSize)
    	);
    }
    
    public class myPoco
    {
    	public string status { get; set;}
    }
