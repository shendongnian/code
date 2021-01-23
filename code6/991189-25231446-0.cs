        using (UserDataDataContext db = new UserDataDataContext())
        {
             return db.mrobProducts.Where(x => x.Status == status).Select(x => new GetAllProducts 
                   { 
                      Name = x.Name, 
                      Desc = x.Description, 
                      Price = x.Price 
                   }).OrderBy(x => x.Price).ToArray();
         }
