            private ApplicationDbContext db = new ApplicationDbContext();
                [HttpGet]
            	public ActionResult GetList()
            	{
    				ViewBag.ProductList = new SelectList(db.tblProducts, "ProductCode", "ProductName");
            		return View();
            		
            	}
