    foreach (var node in ListofLinks)
    {
       
      if (loc.Contains("map="))
      {
        loc = loc.Substring(20);
        coordinates = loc.Split(',');
        newCoordinate.Coordinates.Longitude = (coordinates != null ?   Double.Parse(coordinates[0]) : 0.00);
        newCoordinate.Coordinates.Latitude = (coordinates != null ? Double.Parse(coordinates[1]) : 0.00);
       }
    }    CoOrdinates.Add(newCoordinate);
