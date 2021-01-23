      public void ImportProduct(string file)
        {
            using (var context = new MyContext())
            {
                context.Configuration.AutoDetectChangesEnabled = false;
                List<Product> products = ParseClientFile(file);
                var productMap = context.Products.ToDictionary(x => x.OriginalId, x => x);
                foreach (var item in products)
                {
                    var id = item.OriginalId;
                    Product product;
                    if (!productMap.TryGetValue(id, out product))
                    {
                        product = new Product();
                        product.OriginalId = id;
                        context.Products.Add(product);
                    }
                    product.UPC = string.Empty;
                }
                context.SaveChanges();
            }
      }
