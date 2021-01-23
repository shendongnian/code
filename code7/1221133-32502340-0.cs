    foreach (var product in Products)
    {
        product.Price = Price;
        db.Entry(product).State = EntityState.Modified;
     }
     db.SaveChanges();
