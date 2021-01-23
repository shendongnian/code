    public List<ExampleDataDTO> GetExampleData(int offset = 0, int limit = 0, string name = "", string size = "")
    {
    	using (var db = new Context())
    	{
    		db.Configuration.ProxyCreationEnabled = false;
    		var exampleQuery = db.example
    			.Where((x => x.Name == name || name == "") && // If parameter 'name' has a value, filter on that, else ignore it.
    				   (x => x.Size == size || size == "")) // If parameter 'size' has a value, filter on that, else ignore it.
    			.AsEnumerable()
    			.Select(item =>
    			new ExampleDataDTO
    			{
    				//Selects
    			});
    
    		if (offset == 0 && limit == 0)
    		{
    			return exampleQuery.ToList();
    		}
    		else
    		{
    			return exampleQuery.Skip(offset).Take(limit).ToList();
    		}
    	}
    }
