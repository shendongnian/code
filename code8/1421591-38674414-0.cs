    List<ProductListModel> productList = new List<ProductListModel>();
    
    foreach (var row in datatable.AsEnumerable())
    {
    	var categoryId = row.Field<string>("Category");
    	var product = new ProductModel
    	{
    		Name = row.Field<string>("Name"),
    		Amount = row.Field<double>("Amount")
    	};
    
    	// Build each category
    	if (!productList.Any(x => x.CategoryName == categoryId))
    	{
    		var itemList = new List<ProductModel>();
    		
    		itemList.Add(product);
    		productList.Add(new ProductListModel { CategoryName = categoryId, prodList = itemList });
    	}
    	else
    	{
    		var existingprodList = productList.Where(x => x.CategoryName == categoryId).FirstOrDefault();
    		existingprodList.prodList.Add(product);
    	}
    }
