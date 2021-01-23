      public void ImportProduct(string file)
        {
            using (var context = new LaceupDatabase()) {
                context.Configuration.AutoDetectChangesEnabled = false;
                if (context == null)
                    return;
                List<Product> products = ParseItems(file);
                var productMap = context.Products.ToDictionary(x => x.OriginalId, x => x);
                foreach (var item in products) {
                    var id = item.OriginalId;
                    Product product;
                    bool modified = false;
                    bool newItem = false;
                    if (!productMap.TryGetValue(id, out product)) {
                        product = new Product();
                        product.OriginalId = id;
                        modified = true;
                        newItem = true;
                    }
                    else
                        // This is a reference to another entity
                        if (product.Category != null && item.Category != null && product.Category.Id != item.Category.Id) {
                            context.Configuration.AutoDetectChangesEnabled = true;
                            product.Category = item.Category;
                            // product.CategoryId = item.Category.Id;
                            modified = false;
                            context.SaveChanges();
                            context.Configuration.AutoDetectChangesEnabled = false;
                        }
                    if (newItem || product.Code != item.Code) {
                        product.Code = item.Code;
                        modified = true;
                    }
                    if (newItem) {
                        context.Products.Add(product);
                        context.Entry(product).State = System.Data.Entity.EntityState.Added;
                    }
                    else
                        if (modified)
                            context.Entry(product).State = System.Data.Entity.EntityState.Modified;
                }
                context.SaveChanges();
            }
      }
