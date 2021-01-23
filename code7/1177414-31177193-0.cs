    class MyClass
    {
    	public string disclaimer { get; set; }
    	public string license { get; set; }
    	public string timestamp { get; set; }
    	...
    }
    
    ...
    
    var myObject = JsonConvert.DeserializeObject<MyClass>(responseText);
