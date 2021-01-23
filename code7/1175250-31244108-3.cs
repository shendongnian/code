     public dynamic GetCity(string cityCode,string connection)
                {
                  
                   var cityRepository = new CityRepository(connection);
        
                   if (!cityRepository.IsValidCityCode(model.CityCode))
                   {
                       // Added Model error
                   }
                   return(error);
                }
