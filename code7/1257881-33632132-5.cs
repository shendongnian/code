    public IList<SearchHierarchyModel> GetHierarchyFull(int Continent_Id)
    {
        var countries = db.Countries.Where(c => c.ContinentId == Continent_Id);
        var cities = db.Cities.Where(c => countries.Any(co => co.Id == c.Id));
        var searchList = new List<SearchHierarchyModel>();
        foreach (var item in cities)
        {
            var newItem = new SearchHierarchyModel
            {
                Continent = item.Country.Continent,
                Country = item.Country,
                City = item
            };
            searchList.Add(newItem);
        }
        return searchList;
    }
