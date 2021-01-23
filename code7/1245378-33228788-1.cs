	private async void CurrentLocation()
	{
		try
		{
			Geolocator myGeolocator = new Geolocator();
			Geoposition myGeoposition = await myGeolocator.GetGeopositionAsync(maximumAge: TimeSpan.FromMinutes(5),timeout: TimeSpan.FromSeconds(10));
			
			ReverseGeocodeQuery query = new ReverseGeocodeQuery();
			query.GeoCoordinate = new System.Device.Location.GeoCoordinate(myGeoposition.Coordinate.Latitude, myGeoposition.Coordinate.Longitude);
			
			query.QueryCompleted += (s, e) =>
			{
				if (e.Error != null && e.Result.Count == 0)
					return;
				MessageBox.Show(e.Result[0].Information.Address.PostalCode);
			};
			query.QueryAsync();
			
			double lat = 0.00, lng = 0.00;
			lat = Convert.ToDouble(myGeoposition.Coordinate.Latitude);
			lng = Convert.ToDouble(myGeoposition.Coordinate.Longitude);
			
			this.MyMap.Center = new GeoCoordinate(lat, lng);
			this.MyMap.ZoomLevel = 7;
			this.MyMap.Show();
		}
		catch
		{ }
	}
