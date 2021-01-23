    public static void BatchInsertProducts(IEnumerable<Product> productList)
    {
        using (var context = new DbContext())
        {
            context.Products.AddRange(productList);
            context.SaveChanges();
        }
    }
