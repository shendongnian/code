    private static async Task<Geoposition> GetGeopoisitionWrapper(Geolocator g)
    {
       var accessStatus = await g.RequestAccessAsync();
       Geoposition currentPosition = null;
       switch (accessStatus)
       {
           case GeolocationAccessStatus.Allowed:
              // OK!
              currentPosition = await g.GetGeopositionAsync();                                              // get the raw geoposition data
              break;
           default:
             // Denied !
             break;
        }
        return await Task.FromResult(currentPosition);
    }
