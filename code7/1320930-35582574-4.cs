    // select a supplierId or search by name
    var supplier = OdataContext.Suppliers.FirstOrDefault(s => s.Name == nameToFind);
    if (supplier == null) // Handle no match
    Product p = new Product
    {
        Name = "myname",
        Price = 123.45,
        Category = "myCategory",
        SupplierId = supplier.Id
    }
    OdataContext.Products.Add(p);
    OdataContext.SaveChanges();
