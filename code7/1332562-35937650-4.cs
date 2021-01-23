    public ProductApiCollection Get()
    {
    	var result = new ProductApiCollection
    	{
    		Products = new[]
    		{
    			new ProductApi {Name = "Pork"},
    			new ProductApi {Name = "Beef"},
    			new ProductApi {Name = "Chicken"},
    			new ProductApi {Name = "Salad"}
    		},
    		Status = 1
    	};
    	return result;
    }
