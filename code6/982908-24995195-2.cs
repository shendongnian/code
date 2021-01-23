    [WebMethod()]
    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
    public string[] GetProducts()
    {
    	    var _db = new BundleShop.Models.ProductContext();
            IQueryable<Category> query = _db.Categories;
           	return query.Cast<MyEntityType>().ToArray();;
    }
