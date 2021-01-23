    using (dbContext db = new dbContext())
    {
        var dealers = db.Dealers.AsQueryable();
        if (locations != null)
            dealers = dealers.Where(dealer => locations.Contains(dealer.LocationName));
    
        var query = (from car in db.Cars
                     join dealer in dealers on car.DealerID equals dealer.DealerNumber
                     select new
                     {
                         ID = car.VinNumber,
                         make = car.Make,
                         model = car.Model,
                         Dealer = dealer.DealerName
                      });
    
        return Ok(query.ToList());
    }
