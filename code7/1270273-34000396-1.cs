    private List<tblTest> GetAll(string city, string sexual)
    {
        var query = db.tblTest.AsQueryable();
        if(!string.IsNullOrEmpty(city))
        {
            query = query.Where(x => x.city == city);
        }
        if(!string.IsNullOrEmpty(sexual ))
        {
            query = query.Where(x => x.sexual == sexual );
        }
        return all.ToList();
    }
