    public static Task<List<string>> GetAllPostCodeRegions(string country)
    {
        return Task.Run(() => 
           {
              using (var db = new PlaceDBContext())
              {
                   return db.PostCodes
                            .Where(pc => pc.Country == country)
                            .OrderBy(pc => pc.Region)
                            .Select(pc => pc.Region).Distinct().ToList();
              }
          });        
    }
