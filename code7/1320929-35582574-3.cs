    Supplier s = new Supplier
    {
        Name = "mySupplier"
    }
 
    Product p = new Product
    {
        Name = "myname",
        Price = 123.45,
        Category = "myCategory",
        Supplier = s
    }
    OdataContext.Products.Add(p);
    OdataContext.SaveChanges();
