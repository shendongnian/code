    class Foo<KType, VType>
    {
    	public VType Value;
    	public Dictionary<KType, Foo<KType, VType>> Children;
    }
    
    class Test
    {
    	public Test()
    	{
    		var root = new Foo<int, string>
    		{
    			Value = "root",
    			Children = new Dictionary<int, Foo<int, string>>
    			{
    				{
    					1,
    					new Foo<int, string>
    					{
    						Value = "a",
    						Children = new Dictionary<int, Foo<int, string>>
    						{
    							{1, new Foo<int, string> {Value = "a", Children = null}},
    							{2, new Foo<int, string> {Value = "b", Children = null}}
    						}
    				    }
    				},
    				{
    					2,
    					new Foo<int, string>
    					{
    						Value = "b",
    						Children = null
    				    }
    				}
    			}
    		};
    	}
    }
