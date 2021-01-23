    public JsonResult ProductsRead([DataSourceRequest] DataSourceRequest request) 
    {
    	var products = new northwindEntities().Products
            .Select(p => new ProductModels {  
                ProductID = p.ProductID,
                ProductName = p.ProductName,
                UnitPrice = p.UnitPrice,
                UnitsInStock = p.UnitInStock
            })
            .AsQueryable();
    	
    	return Json(products.ToDataSourceResult(request));
    }
    public ActionResult KendoGrid()
    {
        return View();
    }
