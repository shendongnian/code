    public static void SaveMultipleProducts(IEnumerable<Product> productList)
    {
        using (var context = new DbContext())
        {
            foreach (Account p in productList)
            {
                p.InsertUserId="jtunney";
                p.InsertDate=DateTime.Now;
                context.Entry(p).State=p.Id==0?EntityState.Added:EntityState.Modified;
            }
            context.SaveChanges();
        }
    }
