    foreach (var Destination in Destinations)
    {
    	if (Id != Destination.Id && (ThisDistances.Exists(x => x.Ids.Contains(12) && x.Ids.Contains(21)) == false))
    	{
    		ThisDistances.Add(new DistanceData()
    		{
    			Ids = new int[2] { Id, Destination.Id },
    			Distance = (int)Math.Round(6378388 * Math.Acos(Math.Sin(GeoLat) * Math.Sin(Destination.GeoLat) + Math.Cos(GeoLat) * Math.Cos(Destination.GeoLat) * Math.Cos(Destination.GeoLon - GeoLon)), 0, MidpointRounding.AwayFromZero)
    		});
    		if (++i > 10) break;
    	}
    }
