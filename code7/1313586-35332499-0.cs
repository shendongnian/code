        [HttpGet]
        	public ActionResult GetList()
        	{
        		using (mvcEntities objEntity = new mvcEntities())
        		{
        			ViewBag.ProductList = new SelectList(objEntity.tblProducts, "ProductCode", "ProductName");
        			return View();
        		}
        	}
