    public static void SaveMultipleProducts(IList<Product> productList)
    {
        using (var context = new DbContext())
        {
            foreach (Account p in productList)
            {
                p.InsertUserId="jtunney";
                p.InsertDate=DateTime.Now;
            }
            // Add all records
            context.Products.AddRange(productList);
            // Handle updates
            foreach(var p in productList.Where(p=>p.id!=0))
            {
              context.Entry(p).State=EntityState.Modified;
            }
            context.SaveChanges();
        }
    }
