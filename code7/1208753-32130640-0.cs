     var property = db.Properties.Select(x => new SearchResultsViewModel
     {
          geocoord = new GeoCoordinate { Latitude = (double?)x.latitude ?? 0, Longitude = (double?)x.longitude ?? 0 }
    
     }).AsEnumerable().OrderBy(x=>x.geocoord.GetDistanceTo(coord)).ToList();
