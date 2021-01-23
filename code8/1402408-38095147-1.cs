    Button button = FindViewById<Button>(Resource.Id.myButton);
    
    button.Click += async delegate
    {
        try
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;
    
            if (locator.IsGeolocationEnabled)
            {
                var position = await locator.GetPositionAsync(timeoutMilliseconds: 10000);
                position.ToString();
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Geolocation is disabled!");
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine("Unable to get location, may need to increase timeout: " + ex);
        }
    };
