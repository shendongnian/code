        [ActionName("_ProductTree")]
        public JsonResult GetProductData()
        {
            var products = _productBusinessService.GetProducts();
            foreach (var product in product)
            {
                foreach (var category in client.Categories)
                {
                    category.ProductTypes =
                        _productService.GetProductTypes(category.CategoryId);                                           
                }
            }
            var productTreeData = products.Select(p => new
            {
                Id = p.ProductId,
                Name = p.ProductName,
                HasChildren = p.Categories.Any(),
                Children = p.Categories.Select(c => new
                {
                    Id = c.CategoryId,
                    Name = c.CategoryName,
                    HasChildren = c.ProductTypes.Any(),
                    Children = c.ProductTypes.Select(t => new
                    {
                        Id = t.ProductTypeId,
                        Name = t.ProductTypeName,
                        HasChildren = false
                    }).OrderBy(t => t.Name).ToList()
                }).OrderBy(c => c.Name).ToList()
            }).OrderBy(p => p.Name).ToList();
            return Json(productTreeData, JsonRequestBehavior.AllowGet);
        }
