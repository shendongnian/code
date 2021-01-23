    [Test]
    public void CalculateQueryCount()
    {
    	GlobalCounter.QueryCount = 0;
    
    	using (var context = new YourContext())
    	{
    		//queries
    	}
    
    	int actual = GlobalCounter.QueryCount;
    }
