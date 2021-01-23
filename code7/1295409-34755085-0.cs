    private static async Task<Geoposition> GetGeopoisitionWrapper(Geolocator g)
    {
       var accessStatus = await Geolocator.RequestAccessAsync();
       switch (accessStatus)
       {
           case GeolocationAccessStatus.Allowed:
              // OK!
              Geoposition currentPosition = await g.GetGeopositionAsync();                                              // get the raw geoposition data
              return currentPosition;
              break;
           default:
             // Denied !
             return await Task.FromResult(null);
             break;
        }
    }
