    public ActionResult Index()
    {
       ViewBag.Months = new SelectList(Enumerable.Range(1, 12).Select(x =>
          new SelectListItem()
                  {
                      Text = CultureInfo.CurrentCulture.DateTimeFormat.AbbreviatedMonthNames[x - 1] + " (" + x + ")",
                      Value = x.ToString()
                  }), "Value", "Text");
            ViewBag.Years = new SelectList(Enumerable.Range(DateTime.Today.Year, 20).Select(x =>
               new SelectListItem()
               {
                 Text = x.ToString(),
                 Value = x.ToString()
               }), "Value", "Text");
          ProductStatisticsList p = new ProductStatisticsList();
         // p.Products = new List<ProductStatistics>();
          //p.Products.Add(new ProductStatistics { Product_ID = "Product_ID", ProductName = "ProductName" });
          p.Products = (from productstatistics in db.ProductStatistics
                        select new ProductStatistics
                        {
                            Product_ID = productstatistics.Product_ID,
                            ProductName = productstatistics.ProductName,
                        }).ToList();
            p.SelectedMonth = 3;
            return View(p);
     }
        [HttpPost]
        public ActionResult Index(ProductStatisticsList model)
        {
            //do the stuff
        }
