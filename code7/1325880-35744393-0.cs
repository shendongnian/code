    public ActionResult Create()
		{
			ViewBag.CustomerList =
				db.Customers
				.Select(x => new SelectListItem { Text = x.Name.ToString(), Value = x.CustomerID.ToString() })
				.ToList();
			ViewBag.ProductList = db.Products
				.Select(x => new SelectListItem { Text = x.Name.ToString(), Value = x.CustomerID.ToString() })
				.ToList();
			var m = new Product();
			/*
			 do some initialization on the Product object if required.
			 better still, use a factory method to create new instance of Product.
			*/
			return View(m);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "CustomerID,ProductID,Name,StartDate,Interval,Price,YearPrice,TotalPrice,Category,Paid")] Product product)
		{
			try
			{
				if (ModelState.IsValid)
				{
					/*
					Use some helper method(s) to carry out extra validation on your model; unless it's all done unobtrusively with Validation Attributes
					*/
					db.Products.Add(product);
					db.SaveChanges();
					return RedirectToAction("Index");
				}
			}
			catch (Exception e)
			{
				throw e.InnerException;
			}
			return View(product);
		}
