    List<Product> results = new List<Product>(new Product[]{
        new Product() { ProductCode="ABC ", Name="Shoe", Type="Trainers", Price="3.99" },
        new Product() { ProductCode="ABC ", Name="Shoe", Type="Trainers", Price="4.99" },
        new Product() { ProductCode="ABC ", Name="Shoe", Type="Trainers", Price="5.99" },
        new Product() { ProductCode="ABC ", Name="Shoe", Type="Heels", Price="3.99" },
        new Product() { ProductCode="ABC ", Name="Shoe", Type="Heels", Price="4.99" },
        new Product() { ProductCode="ABC ", Name="Shoe", Type="Heels", Price="5.99" },
    });
    
    results = (from e in results
               group e by Tuple.Create(e.ProductCode, e.Name, e.Type) into g
               select new Product
               {
                   ProductCode = g.Key.Item1,
                   Name = g.Key.Item2,
                   Type = g.Key.Item3,
                   Price = (from p in g select double.Parse(p.Price, CultureInfo.InvariantCulture)).Sum().ToString("0.00", CultureInfo.InvariantCulture)
               }).ToList();
