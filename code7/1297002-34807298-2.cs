	public void POIList()
	{
		foreach (string line in File.ReadLines("POIList.txt"))
		{
			string[] parts = line.Split(new[] { ';' }, 
				StringSplitOptions.RemoveEmptyEntries);
			
			if (parts.Length == 0)
			{
				// Empty line or similar.
				continue;
			}
			
			string cityName = parts[0];
			
			poi.Add(cityName, new List<string>());
			
			// Add the points of interest to local.
			var points = new List<string>(parts.Skip(1));
			poi[cityName] = points;
			
			// basePath will have to be retrieved somehow. It's up to you.
			string cityDirectoryPath = Path.Combine(basePath, cityName));
			
            // Create a directory for the city.
			Directory.CreateDirectory(cityDirectoryPath);
			
            // Create sub-directories for points.
			foreach (string point in points)
			{
				Directory.CreateDirectory(Path.Combine(
					cityDirectoryPath, point));
			}
		}
	}
