     public ActionResult GetList(int? ProductList)
        {
            using (mvcEntities objEntity = new mvcEntities())
            {
                List<tblProduct> Products = objEntity.tblProducts.ToList();
                ViewBag.ProductList = new SelectList(Products, "ProductCode", "ProductName" ,ProductList);
                return View(Products);
        }
    }
