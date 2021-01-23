    private void Test(object inputs)
    {
    	var typeAs = inputs as IEnumerable<TypeA>;
    	if (typeAs != null)
    	{
    		foreach (var item in typeAs)
    		{
    
    		}
    		return;
    	}
    	var typeBs = inputs as IEnumerable<TypeB>;
    	if (typeBs != null)
    	{
    		foreach (var item in typeBs)
    		{
    
    		}
    		return;
    	}
    	
    	throw new ArgumentException("inputs");
    }
