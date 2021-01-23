    public static class WidgetWorker
    {
    	public static void Main()
    	{
    		//setup
    		var widgetCollection = new MongoClient("mongodb://localhost:27017")
    			.GetDatabase("WidgetDatabase")
    			.GetCollection<Widget>("Widget");
    		widgetCollection.DeleteManyAsync(x => true).Wait();   //remove all existing rows
    
    		//create widgets and add to DB;  2 SKUs, each with multiple revisions
    		var widgetA1 = new Widget() { SKU = "aaaa", Revision = 1M, Cost = 10 };
    		var widgetA2 = new Widget() { SKU = "aaaa", Revision = 2.1M, Cost = 20 };
    		var widgetA3 = new Widget() { SKU = "aaaa", Revision = 2.2M, Cost = 30 };
    		var widgetB1 = new Widget() { SKU = "bbbb", Revision = 1M, Cost = 40 };
    		var widgetB2 = new Widget() { SKU = "bbbb", Revision = 1.1M, Cost = 50 };
    		widgetCollection.InsertManyAsync(new[] { widgetA1, widgetA2, widgetA3, widgetB1, widgetB2 }).Wait();
    
    		//get the ObjectId of the most Recent revision of each SKU
    		var r = widgetCollection
    			.Aggregate()
    			.SortByDescending(x => x.Revision)
    			.Group(x => x.SKU, g => new { Id = g.First().Id })
    			.ToListAsync()
    			.Result;
    
            //get the Widget objects for the list of ids just collected
            var ids = r.Select(x => x.Id).ToArray();
    		var widgets = widgetCollection
    			.Find(x => ids.Contains(x.Id))
    			.ToListAsync()
    			.Result;
    			
    		//check results
    		Debug.Assert(widgets.Count() == 2);
    		Debug.Assert(widgets.Single(x => x.SKU == "aaaa").Revision == 2.2M);
    		Debug.Assert(widgets.Single(x => x.SKU == "bbbb").Revision == 1.1M);
    	}
    }
    
    public class Widget
    {
    	[BsonId]
    	public ObjectId Id { get; set; }
    	public string SKU { get; set; }
    	public decimal Revision { get; set; }
    	public decimal Cost { get; set; }
    }
