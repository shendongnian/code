    static void Main(string[] args)
        {
            myGeolocator = new Geolocator() { DesiredAccuracy = PositionAccuracy.High };
            var geopositionAsyncResult = myGeolocator.GetGeopositionAsync();
            geopositionAsyncResult.Completed = GetGeopositionCompleted;
            Console.ReadKey();
        }
        private static void GetGeopositionCompleted(IAsyncOperation<Geoposition> asyncInfo, AsyncStatus asyncStatus)
        {
            switch (asyncStatus)
            {
                case AsyncStatus.Completed:
                    var result = asyncInfo.GetResults();
                    var possition = result.Coordinate.Point.Position;
                    Console.WriteLine(String.Format("Latitude = {0} Longitude = {1}", possition.Latitude, possition.Longitude));
                    break;
                default:
                    Console.WriteLine(myGeolocator.LocationStatus.ToString());
                    break;
            }
        }
