    public class LocationService
    {
        public static Task<Location> ReverseGeocode(double lat, double lon)
        {
            TaskCompletionSource<Location> completionSource = new TaskCompletionSource<Location>();
            var geocodeQuery = new ReverseGeocodeQuery();
            geocodeQuery.GeoCoordinate = new GeoCoordinate(lat, lon);
            EventHandler<QueryCompletedEventArgs<IList<MapLocation>>> query = null;
            query = (sender, args) =>
                {
                    geocodeQuery.QueryCompleted -= query;
                    MapLocation mapLocation = args.Result.FirstOrDefault();
                    var location = Location.FromMapLocation(mapLocation);
                    completionSource.SetResult(location);
                };
            geocodeQuery.QueryCompleted += query;
            geocodeQuery.QueryAsync();
        }
    }
