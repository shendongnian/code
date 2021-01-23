    static void Main(string[] args)
        {
            GeoCoordinateWatcher watcher;
            watcher = new GeoCoordinateWatcher();
            watcher.PositionChanged += (sender, e) =>
            {
                var coordinate = e.Position.Location;
                Console.WriteLine("Lat: {0}, Long: {1}", coordinate.Latitude, coordinate.Longitude);
                // Uncomment to get only one event.
                watcher.Stop();
            };
            // Begin listening for location updates.
            watcher.Start();
            Console.ReadKey();
        }
