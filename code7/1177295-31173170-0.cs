    [Route("")] 
    public IHttpActionResult Get() 
    { 
    	IDictionary<MyClass, int> resource = new Dictionary<MyClass, int> 
    	{
    		{ new MyClass {Property1="1", Property2=2, Property3=3}, 0 },
    		{ new MyClass {Property1="11", Property2=22, Property3=33}, 1 },
    	};
    	
    	return Ok(resource); 
    } 
