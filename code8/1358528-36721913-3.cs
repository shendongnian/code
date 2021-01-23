     public ActionResult Index(int ProductId = 0)
            {
                var model = new Product
                {
                    Products = db.Products.ToList(),
                    Stock = ProductId != 0 ? db.Products.Where(x=>x.ProductId == ProductId).FirstOrDefault().Stock : null
                };
                return View(model);
            }
