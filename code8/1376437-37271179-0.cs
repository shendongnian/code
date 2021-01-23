    private async Task<City> RetrieveCity(string name)
    {
     // Instantiate return variable
     City city = null;
     // Find id in ProductLines table
     var cities = await db.Cities.Where(c => c.CityName.Equals(name)).ToListAsync();
     if(cities!=null && cities.Count()>0)
     { 
        city = cities.First();
     }   
     return city;           
    }
