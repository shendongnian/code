		var liveUpdate = xml.Root;
		var e = liveUpdate;
		var clients = new Client()
					{
						cityID = e.Element("CityID").Value,
						cityName = e.Element("CityName").Value,
						userName = e.Element("UserName").Value,
						//dateTime = e.Element("DateTime").Value,
						appList = e.Element("ApplicationDetails").Elements("ApplicationDetail")
									.Select(a => new Apps()
									{
										app = a.Attribute("Application").Value,
										licensed = a.Attribute("Licensed").Value,
										version = a.Attribute("Version").Value,
										patch = a.Attribute("Patch").Value
									}).ToList()
					};
