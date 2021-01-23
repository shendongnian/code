        [HttpGet]
        	public ActionResult GetList()
        	{
        		
        	    IQueryable<tblProduct> tblProducts;
			    using (mvcEntities objEntity = new mvcEntities())
			    {
				    ViewBag.ProductList = new SelectList(objEntity.tblProducts, "ProductCode", "ProductName");
				    return View(Products);
		        }
        		return View();
        		
        	}
