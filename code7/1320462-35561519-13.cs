    var today = DateTime.UtcNow.Date; // lock in UTC date so it doesn't vary during the query
    var result =
        from f in MyDC.Fruits
        orderby f.ExpirationDate
        where f.ExpirationDate < today
        group f by f.BasketID into basket
        let summary = new
        {
           BasketID = basket.Key,
           MostRecentlyExpiredFruit = basket.Last()
        }
        select new MyModel
        {
            BasketID = summary.BasketID,
            MostRecentlyExpiredFruitID = summary.MostRecentlyExpiredFruit.FruitID,
            MostRecentlyExpiredFruitName = summary.MostRecentlyExpiredFruit.Name,
            HowLongSinceMostRecentExpiration =
                today - summary.MostRecentlyExpiredFruit.ExpirationDate
        };
