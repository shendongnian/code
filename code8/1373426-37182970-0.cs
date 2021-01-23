     public static int CopyProduct(int productId)
            {
    
                Products productToCopy;
                using (var db = new DXLEntities())
                {
                    productToCopy = db.Products.FirstOrDefault(p => p.ProductId == productId);
                }
    
                using (var db = new DXLEntities())
                {
                    productToCopy.ProductId = 0;
                    db.Products.Add(productToCopy);
                    db.SaveChanges();
                    return productToCopy.ProductId;
                }
            }
