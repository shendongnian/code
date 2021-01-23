    public static DbContext BatchInsertProducts(DbContext context,IList<Product> productList)
    {
        context.Configuration.AutoDetectChangesEnabled = false;
        for (int i = 0; i < lobbies.Count; i += 100)
        {
            context.Set<Product>().AddRange(lobbies.GetRange(i, Math.Min(100, lobbies.Count - i)));
            context.Products.AddRange(productList);
            context.SaveChanges();
            //Dispose and create a context
            context.Dispose();
            context = new DbContext;
            context.Configuration.AutoDetectChangesEnabled = false;   
        }
        return context;
    }
