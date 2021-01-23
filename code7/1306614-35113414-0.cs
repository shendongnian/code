    public Product UpdateProduct(ProductVM objProduct)
    {
        obj = JsonConvert.DeserializeObject<Product>(JsonConvert.SerializeObject(objProduct));
    	
    	//Get the product from DB to update
    	var product = DbContext.SingleOrDefult(x => x.Id == objProduct.Id);
    	
    	//update fields...
    	product.SomeField = objProduct.SomeField;
    	
    	//Save changes
        DbContext.Entry(obj).State = EntityState.Modified;
        DbContext.SaveChanges();
    	
        return product;
    }
