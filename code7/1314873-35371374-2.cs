    public ActionResult TestData()
    {
            List<Product> products = new List<Product>();
            var db = new HotStuffPizzaContext();
            var result = (from p in db.Products
                          select p)
                          .Where(x => x.ProductID != 0)
                          .Select(a => new
                          {
                              productid= a.ProductID,
                              description = a.Description
                          });
            return Json(result.ToList(), JsonRequestBehavior.AllowGet);
    }
