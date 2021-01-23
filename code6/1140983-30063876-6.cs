    var client = new ODataClient(settings);
    var packages = await client.For("HIP").FindEntriesAsync();
    var hcp = new List<HIP>();
    var properties = typeof(Hip).GetProperties();
    
    foreach (var p in packages)
    {
    	var hip = new HIP();
    
    	foreach (var prop in properties)
    	{
    		prop.SetValue(hip, Convert.ChangeType(p[prop.Name], prop.PropertyType), null);
    	}
    	
    	hcp.Add(hip);
    }
