    public ProductApiCollection Get()
    {
       	var result = new ProductApiCollection();
    	var dbProducts = db.Products;
    	var apiModels = dbProducts.Select(x => new ProductApi { Name = x.Name } ).ToArray();
    	result.Products = apiModels;
    	
    	var status = db.Status.Any() ? 1 : 0;
    	result.Status = status;
    	
     	return result;
    }
