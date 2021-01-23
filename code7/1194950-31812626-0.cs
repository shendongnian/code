            geolocator = new Geolocator();
            geolocator.DesiredAccuracy = PositionAccuracy.High;
            geolocator.ReportInterval = 2000;
            geolocator.PositionChanged += geolocator_PositionChanged;
    
        private void geolocator_PositionChanged(Geolocator sender, PositionChangedEventArgs args)
        {
            Dispatcher.BeginInvoke(() =>
            {
                if (args.Position != null && args.Position.Coordinate.ToGeoCoordinate() != myPosition)
                {
                    if(args.Position.Coordinate.Accuracy <= 1500)
                    {
                        myPosition = args.Position.Coordinate.ToGeoCoordinate();
                        UpDateMyPositionCircle(args.Position.Coordinate.Accuracy);
                    }
                }
            });
        }
