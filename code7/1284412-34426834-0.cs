    public static IEnumerable<MyObject> GetObjects()
    {
    	var i = 0;
    	while(i < 30)
    		yield return new MyObject { Name = "Object " + i++ };
    }
