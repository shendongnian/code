    public IList<SearchHierarchyModel> GetHierarchyFull(int Continent_Id)
    {
        var continent = db.Continents.FirstOrDefault(c => c.Id == Continent_Id);
        //Get all countries with a specified ContinentId
        var countryList = db.Countries.Where(c => c.ContinentId == Continent_Id);
        //Get all cities that have a matching CountryId from any country in the first list.
        var cityList = db.Cities.Where(c => countryList.Any(cl => cl.Id == c.CountryId)).ToList();
        //We need to get the original countryList as a true list rather than a collection of entities.
        //If we had called ToList above, it would error out.
        //If we had called ToList in the ForEach loop, we also would have issues.
        var countryList2 = countryList.ToList();
        var searchList = new List<SearchHierarchyModel>
        {
            new SearchHierarchyModel()
            {
                Continent = new List<Continent> { continent },
                Country = countryList2,
                City = cityList
            }
        };
        return searchList;
    }
