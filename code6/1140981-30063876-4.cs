    var client = new ODataClient(settings);
    var packages = await client.For("HIP").FindEntriesAsync();
    var hip = new HIP();
    var properties = typeof(Hip).GetProperties();
    
    foreach (var p in properties)
    {
    	p.SetValue(hip, Convert.ChangeType(packages[p.Name], p.PropertyType), null);
    }
