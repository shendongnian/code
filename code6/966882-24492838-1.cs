    List<Product> products = new List<Product>();
    products.Add(new Product() { ProductId = 1, ProductDescription = "Product 1" });
    products.Add(new Product() { ProductId = 2, ProductDescription = "Product 2" });
    products.Add(new Product() { ProductId = 3, ProductDescription = "Product 3" });
    products.Add(new Product() { ProductId = 1, ProductDescription = "Product 1 again" });
    var distictItems = products.Distinct().ToList();
    Console.WriteLine(distictItems.Count()); //This prints 3
