        [HttpGet]
        	public ActionResult GetList()
        	{
			    mvcEntities objEntity = new mvcEntities();
				ViewBag.ProductList = new SelectList(objEntity.tblProducts, "ProductCode", "ProductName");
				return View(Products);
		        
        		return View();
        		
        	}
