    [HttpPost]
    public ActionResult Products(int orderyBy, int page = 1, int pageSize = 9)
    {
         switch (orderyBy)
         {
             case 1:
                 List<Product> listProductsasc = db.Products.OrderBy(p=>p.Name).ToList();
                 PagedList<Product> modelasc = new PagedList<Product>(listProductsasc, page, pageSize);
                 return View(modelasc);
             case 2:
                 List<Product> listProductsdesc = db.Products.OrderByDescending(p=>p.Name).ToList();
                 PagedList<Product> modeldesc = new PagedList<Product>(listProductsdesc, page, pageSize);
                 return View(modeldesc);
             default:
                 List<Product> listProducts = db.Products.ToList();
                 PagedList<Product> model = new PagedList<Product>(listProducts, page, pageSize);
                 return View(model);
         }
     }
