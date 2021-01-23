    var customersDictionary = 
		xDoc.Root
			.Elements("cust")
			.ToDictionary(xe => 
							xe.Attribute("Name").Value, xe => 
							new Customers
							{
								DeviceID = (int)xe.Attribute("DeviceID"), 
								Longitude = (int)xe.Attribute("Longitude"),  
								Latitude = (int)xe.Attribute("Latitude"),
								Device = (string)xe.Attribute("Device")
							});
