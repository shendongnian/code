    public IList<SearchHierarchyModel> GetHierarchyFull(int Continent_Id)
    {
        var continent = db.Continents.FirstOrDefault(c => c.Id == Continent_Id);
        if (continent == null)
            return null;
        var searchList = (from item in continent.Countries
            from city in item.Cities
            select new SearchHierarchyModel
            {
                Continent = continent, 
                Country = item, 
                City = city
            }).ToList();
        return searchList;
    }
