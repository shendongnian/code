    class MyClass
    {
    	public string disclaimer { get; set; }
    	public string license { get; set; }
    	public string timestamp { get; set; }
    	...
    }
    
    [HttpPost]
    public ActionResult Index(Test1 values)
    {
    	...
    	var myObject = JsonConvert.DeserializeObject<MyClass>(responseText);
    	...
    }
