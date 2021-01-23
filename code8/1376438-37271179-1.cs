    private async Task<City> RetrieveCity(string name)
    {
         var city = await db.Cities.FirstOrDefault(c => c.CityName.Equals(name));
         return city;           
    }
    
