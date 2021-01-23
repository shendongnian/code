    private void GestureListener_Tap(object sender, GestureEventArgs e)
        {
            try
            {
                var point = new Point(e.GetPosition(MapControl).X, e.GetPosition(MapControl).Y);
                var location = MapControl.ViewportPointToLocation(point);
                Pushpin.Location = location;
                Pushpin.Content = "loading...";
                var request = new ReverseGeocodeRequest()
                {
                    Location = location,
                    Credentials = new Credentials()
                    {
                        ApplicationId = "YourAPP_ID"
                    }
                };
                // prepare the service
                GeocodeServiceClient service = new GeocodeServiceClient(new BasicHttpBinding(), new EndpointAddress("http://dev.virtualearth.net/webservices/v1/geocodeservice/geocodeservice.svc"));
                service.ReverseGeocodeCompleted += service_ReverseGeocodeCompleted;
                service.ReverseGeocodeAsync(request);
            }
            catch (Exception)
            {
                MessageBox.Show("Couldn't communicate with server");
            }
        }
        void service_ReverseGeocodeCompleted(object sender, ReverseGeocodeCompletedEventArgs e)
        {
            if (e.Result.Results.Count > 0)
                Pushpin.Content = e.Result.Results[0].Address.FormattedAddress;
            else
                Pushpin.Content = "Invalid";
        }
