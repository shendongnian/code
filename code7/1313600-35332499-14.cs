            private ApplicationDbContext db = new ApplicationDbContext();
                [HttpGet]
            	public ActionResult GetList()
            	{
                    List<tblProduct> Products = db.tblProducts.ToList();
    				ViewBag.ProductList = new SelectList(Products, "ProductCode", "ProductName");
            		return View();
            		
            	}
