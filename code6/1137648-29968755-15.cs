    List<Advert> adverts = db.Adverts.OrderByDescending(a => a.AdvertView).ToList();
    List<Product> products = db.Products.OrderBy(d => d.ProductDateCreated).ToList();
    List<Items> ResultList = new List<Items>();
    for (int i = 0; i < products.Count; i++)
    {
        ResultList.Add(products[i]);
        if ((i + 1) % 5 == 0)
        {
            int advertsIndex = i / 5;
            if (adverts.Count + 1 >= advertsIndex)
                ResultList.Add(adverts[advertsIndex]);
        }
    }
