    public class Location_Android : Activity, ILocation
        {
            public async Task<Position> GetLocation()
            {
                return await GetPosition();
    
            }
    
            private async Task<Position> GetPosition()
            {
                Position result = null;
                try
                {
                    var locator = CrossGeolocator.Current;
                    locator.DesiredAccuracy = 50;
                    if (locator.IsListening != true)
                    {
                        locator.StartListening(minTime: 1000, minDistance: 0);
                    }
                    var position = await locator.GetPositionAsync(10000);
                    //You can use Xamarin.Forms.Maps.Position
                    //Here I use a personnal class
                    result = new Position(position.Longitude, position.Latitude);
    
                }
                catch (Exception e)
                {
                    Log.Debug("GeolocatorError", e.ToString());
                }
                return result;
            }
        }
