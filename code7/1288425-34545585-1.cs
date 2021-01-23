    //Add breakpoint in this line
    Product product = db.Products.Find(id); 
    db.Database.Log = sql => System.Diagnostics.Debug.WriteLine(sql);
    var prodPrices = product.ProdPrices.ToList();
    //Next line
