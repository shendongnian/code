    static void Main(string[] args)
    {
    	using (var context = new Context())
    	{
    		var results = from w in context.what
    					  select w;
    
    		foreach (var what in results)
    		{
    			Console.WriteLine("what.primary_key_what = {0}", what.primary_key_what);
    			Console.WriteLine("what.another_column_what = {0}", what.another_column_what);
    			Console.WriteLine("what has {0} whys", what.whys.Count);
    			foreach (var why in what.whys)
    			{
    				Console.WriteLine("Why.primary_key_why = {0}", why.primary_key_why);
    				Console.WriteLine("Why.some_column_why = {0}", why.some_column_why);
    			}
    		}
    	}
    }
