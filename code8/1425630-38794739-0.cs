        GeoCoordinateWatcher _watcher;
        public Class1()
        {
            _watcher = new GeoCoordinateWatcher();
            _watcher.StatusChanged += Watcher_StatusChanged;
            _watcher.PositionChanged += GeoPositionChanged;
            _watcher.Start();
            var coord = _watcher.Position.Location;
        }
        private void Watcher_StatusChanged(object sender, GeoPositionStatusChangedEventArgs e)
        {
            if (e.Status == GeoPositionStatus.Ready)
            {
                MessageBox.Show("Watcher is ready. First location: The current location is: " +
              _watcher.Position.Location.Latitude + "/" +
              _watcher.Position.Location.Longitude + ".");
            }
        }
        private static void GeoPositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            MessageBox.Show("The current location is: " +
                e.Position.Location.Latitude + "/" +
                e.Position.Location.Longitude + ".");
        }
