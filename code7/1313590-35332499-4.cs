        [HttpGet]
        	public ActionResult GetList()
        	{
        		
        	    ViewBag.ProductList = new SelectList(new List<SelectListItem> { 
                        new SelectListItem{ Text = "name_x", Value = "name_x"},
                        new SelectListItem{ Text = "name_y", Value = "code_y"}
                         }, "Value", "Text");
        		return View();
        		
        	}
