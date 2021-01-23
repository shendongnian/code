			var data = new ItemDestination
			{
				DestinationType = "geocode",
				Longitude = "2.64663399999995",
				Latitude = "39.57119",
				RadiusKm = "5"
			};
			var serializer = new XmlSerializer( typeof( ItemDestination ) );
			var writer = new StringWriter();
			serializer.Serialize( writer, data );
			writer.Flush();
			var xmlRequest = writer.GetStringBuilder().ToString();
