    try
    {
      using (UserDataDataContext db = new UserDataDataContext())
      {
        return db.mrobProducts.Where(x => x.Status == 1).Select(x => new { x.Name,x.Id, x.Price}).OrderBy(x => x).ToArray();
      }
    }
