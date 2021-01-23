    IList<Product> newProducts = new List<Products>();
    newProducts.Add(new Product() { Name = "A" });
    newProducts.Add(new Product() { Name = "b" });
    newProducts.Add(new Product() { Name = "C" });
               
    using (var context = new YourDbContext())
    {
        context.Products.AddRange(newProduct);
        context.SaveChanges();
    }
