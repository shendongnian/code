    List<Adverts> adverts = db.Adverts.OrderByDescending(a => a.AdvertView).ToList();
    List<Product> products = db.Products.OrderBy(d => d.ProductDateCreated).ToList();
    List<Items> ResultList = new List<Items>();
    for (int i = 0; i < products.Count; i++)
    {
        ResultList.Add(products[i]);
        if (i % 5 == 0 && i > 1)
        {
            if(adverts.Count >= (i / 5))
               ResultList.Add(adverts[i / 5]);
        }
    }
