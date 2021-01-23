	Dictionary<UTMCoordinate, int> planes = new Dictionary<UTMCoordinate, int>();
	UTMCoordinate nCoord    = new UTMCoordinate(337394.136407966, 6263820.40182064, 0, 56, UTMCoordinate.Hemisphere.H_SOUTHERN);
	planes[nCoord]          = 1;
	
	bool exists = planes.ContainsKey(nCoord);
