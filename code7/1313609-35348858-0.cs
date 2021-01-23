    public ActionResult GetList()
        {
            using (mvcEntities objEntity = new mvcEntities())
            {
                List<tblProduct> Products = objEntity.tblProduct.ToList();
                ViewBag.ProductList = new SelectList(Products, "ProductCode", "ProductName");
                return View();
            }
        }
