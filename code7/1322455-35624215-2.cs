       public ActionResult Index()
        {
            ViewBag.Months = new SelectList(Enumerable.Range(1, 12).Select(x =>
                  new SelectListItem()
                  {
                      Text = CultureInfo.CurrentCulture.DateTimeFormat.AbbreviatedMonthNames[x - 1] + " (" + x + ")",
                      Value = x.ToString(),
                      Selected = true
                  }), "Value", "Text");
            var data = (from productstatistics in db.ProductStatistics
                        select new ProductStatistics
                        {
                            Product_ID = productstatistics.Product_ID,
                            ProductName = productstatistics.ProductName,
                        }).ToList();
            return View(data);
        }
