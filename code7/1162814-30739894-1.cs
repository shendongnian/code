    public static void BatchInsertProducts(IEnumerable<Product> productList)
    {
        using (var context = new DbContext())
        {
            context.Products.AddRange(productList);
            context.SaveChanges();
        }
    }
    public static void SaveMultipleProducts(IList<Product> productList)
    {
        using (var context = new DbContext())
        {
            foreach (Account p in productList)
            {
                context.Entry(p).State=p.Id==0?EntityState.Added:EntityState.Modified;
                p.InsertUserId="jtunney";
                p.InsertDate=DateTime.Now;
            }
            context.SaveChanges();
        }
    }
