	try
	{
			LineString lineString = new LineString()
			{
				AltitudeMode = AltitudeMode.Absolute,
				Tessellate = true,
				Coordinates = new CoordinateCollection()
			};
			Vector prevCoordinates = new Vector(45.883144378662109, 13.902674674987793, -71.5);
			lineString.Coordinates.Add(prevCoordinates);
			Placemark placemark = new Placemark()
			{
				Name = "Coordinate log",
				Geometry = lineString
			};
			placemark.AddStyle(new Style()
			{
				Line = new LineStyle()
				{
					ColorMode = ColorMode.Normal,
					Width = 3,
					Color = new Color32(255, 255, 0, 0),
					OuterWidth = 1,
					OuterColor = new Color32(150, 255, 255, 255),
				},
			});
			KmlFile kml = KmlFile.Create(placemark, false);
			using (var stream = System.IO.File.OpenWrite(telemFileName + ".kml"))
			{
				kml.Save(stream);
			}
	}
	catch (IOException)
	{
		//file in use
	}
	catch (Exception ex)
	{
		logger.Error("Exception: " + ex);
	}
