    public override IEnumerable<WeatherService.Domain.DataModels.Location> GetLocation(string locationName)
    {
        IEnumerable<WeatherService.Domain.DataModels.Location> locations = _iWeatherRepository.FindLocationByName(locationName);
    
        if (locations == null || locations.Count() == 0)
        {
            var entities = _geoNameWebservice.GetLocation(locationName); 
    
            foreach (var entity in entities)
            {
                var location = new WeatherService.Domain.DataModels.Location();
                //Copy the properties over to your domain model
                location.Property1 = entity.Property1;
                //...code removed for brevity
                _iWeatherRepository.AddLocation(location);
            }
            _iWeatherRepository.Save();
            locations = _iWeatherRepository.FindLocationByName(locationName)
        }
    
        return locations;
    }
