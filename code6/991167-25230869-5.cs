    public NamePriceModel[] AllProducts()
    {
        try
        {
            using (UserDataDataContext db = new UserDataDataContext())
            {
                return db.mrobProducts
                    .Where(x => x.Status == 1)
                    .Select(x => new NamePriceModel { 
                        Name = x.Name, 
                        Id = x.Id, 
                        Price = x.Price
                    })
                    .OrderBy(x => x.Id)
                    .ToArray();
             }
         }
         catch
         {
             return null;
         }
     }
