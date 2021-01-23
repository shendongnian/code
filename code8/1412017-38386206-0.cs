        public IQueryable<Product> GetProduct([QueryString("srch")] string ProductName)
        {
            var _db = new project.Models.ProductContext();
            IQueryable<Product> query = _db.Products;
            if (!string.IsNullOrEmpty(ProductName))
            {
                query = query.Where(p => p.ProductName == ProductName);
            }
            else
            {
                query = null;
            }
            return query;
        }
