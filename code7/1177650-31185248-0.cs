    public Task<BackOfficeResponse<List<Country>>> ReturnAllCountries()
    {
        using (db = myDBContext.Get()) {
          var list = await db.Countries.Where(condition).ToListAsync();
           return list;
        }
    }
