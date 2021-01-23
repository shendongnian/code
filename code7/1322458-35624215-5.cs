        public ActionResult Index()
        {
            ViewBag.Months = new SelectList(Enumerable.Range(1, 12).Select(x =>
                  new SelectListItem()
                  {
                      Text = CultureInfo.CurrentCulture.DateTimeFormat.AbbreviatedMonthNames[x - 1] + " (" + x + ")",
                      Value = x.ToString(),
                      Selected = true
                  }), "Value", "Text");
            ProductStatisticsList p = new ProductStatisticsList();
            p.Products = new List<ProductStatistics>();
            p.Products.Add(new ProductStatistics { Product_ID = "Product_ID", ProductName = "ProductName" });
            //p.Products = (from productstatistics in db.ProductStatistics
            //            select new ProductStatistics
            //            {
            //                Product_ID = productstatistics.Product_ID,
            //                ProductName = productstatistics.ProductName,
            //            }).ToList();
            p.SelectedMonth = 3;
            return View(p);
        }
