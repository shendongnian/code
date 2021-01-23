    public async Task<Coordinates> GeoCode(string address) 
    {
        GoogleGeocoder geocoder = new GoogleGeocoder();
        IEnumerable<GoogleAddress> addresses = await geocoder.GeocodeAsync(address);    
    
        GoogleAddress first = addresses?.FirstOrDefault();
    
        return first == null
            ? null
            : new Coordinates
            {
                Latitude = first.Coordinates.Latitude,
                Longitude = first.Coordinates.Longitude
            };
    }
