    var Latitude;
    var Longitude;    
    var request = new GeolocationRequest(GeolocationAccuracy.Best);
                        var location = await Geolocation.GetLocationAsync(request);
        
                        if (location != null)
                        {
                            if (location.IsFromMockProvider)
                            {
                                //Put a message if detect a mock location.
                            }else
                            {
                                Latitude=location.Latitude;
                                Longitude=location.Longitude;
                            }
                        }
