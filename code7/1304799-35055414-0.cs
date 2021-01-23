    public DateTime GetLocalTime(
    DateTime utcDate, double latitude, double longitude )
    {
    var request = new TimeZoneRequest
    {
    ApiKey = _apiConfiguration.GoogleApiKey,
    Location = new Location(latitude, longitude),
    TimeStamp = utcDate,
    Sensor = false
    };
    
    var response = GoogleMaps.TimeZone.Query(request);
    
    if (response.Status != GoogleMapsApi.Entities.TimeZone.Response.Status.OK) 
    return utcDate;
    
    var offset = TimeSpan.FromSeconds(response.RawOffSet + response.OffSet);
    var timeZone = TimeZoneInfo.CreateCustomTimeZone(response.TimeZoneId, offset, response.TimeZoneName, response.TimeZoneName);
    var localTime = TimeZoneInfo.ConvertTimeFromUtc(utcDate, timeZone);
    
    return localTime;
    }
