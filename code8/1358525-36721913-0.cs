     public ActionResult Index(int ProductId = 0)
        {
             var productList = db.Products.ToList();
             ViewBag.Products = productList;
             if(ProductId!=0)
             {
               //do the logic to get the stock
             }
             return View();
        }
