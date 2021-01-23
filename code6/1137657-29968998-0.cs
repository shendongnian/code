    var products = db.Products.OrderBy(d => d.ProductDateCreated).ToList();
    var adverts = db.Adverts.OrderByDescending(a => a.AdvertView).ToList();
            
    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine(products[i].ProductName);
        if ((i + 1) % 5 == 0) 
        {
            Console.WriteLine(adverts[(i / 5) % adverts.Count].AdvertName);
        }
    }
