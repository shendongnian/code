    List<object> allItems = new List<object>();
    int numOfProdPerPage = 5;
    int n = ... // number of products to be listed
    var products = db.Products.OrderBy(d=>d.ProductDateCreated);
    var adverts = db.Adverts.OrderByDescending(d=>d.AdvertView);
    for(int p = 0; p< n / numOfProdPerPage ; p++)
    {
        var productsPerPage = products.Skip(numOfProdPerPage * p)
                                      .Take(numOfProdPerPage ).ToList();
        allItems.AddRange(products);
        Advert advert = adverts.ElementAt<Advert>(p);
        allItems.Add(advert);
    }
