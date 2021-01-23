    locationManager = (LocationManager)GetSystemService(Context.LocationService);
    
    Criteria criteria = new Criteria();
    criteria.Accuracy = Accuracy.Fine;
    criteria.PowerRequirement = Power.Low;
    
    provider = locationManager.GetBestProvider(criteria, true);
    
    location = locationManager.GetLastKnownLocation(provider);
    marker1lat = location.Latitude;
    marker1lng = location.Longitude;
    marker2lat = location.Latitude;
    marker2lng = location.Longitude;
  
    LatLng marker1LatLng = new LatLng(marker1lat, marker1lng);
    Latlng marker2LatLng = new LatLng(marker2lat, marker2lng);
    
    LatLngBounds.Builder b = new LatLngBounds.Builder()
                        .Include(marker1LatLng)
                        .Include(marker2LatLng);
    mMap.MoveCamera(CameraUpdateFactory.NewLatLngBounds(b.Build(), 120));
