     public IList<SearchHierarchyModel> GetHierarchyFull(int Continent_Id)
     {
         using (var context = new YourContext()) 
         {
             var continent = context.Continents.FirstOrDefault(c=>c.Id == Continent_Id);
             //Get all countries with a specified ContinentId
             var countryList = context.Countries.Where(c => c.ContinentId == Continent_Id);
             //Get all cities that have a matching CountryId from any country in the first list.
             var cityList = context.Cities.Where(c => countryList.Any(cl => cl.Id == c.CountryId));
             var searchList = new List<SearchHierarchyModel>();
             foreach(var item in cityList)
             {
                 var newItem = new SearchHierarchyModel 
                     {
                         Continent = new List<Continent> {continent},
                         Country = countryList,
                         City = cityList
                     };
                 searchList.Add(newItem);
              }
         }
    }
