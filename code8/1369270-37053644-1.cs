    XDocument doc = XDocument.Parse("<?xml version=\"1.0\" encoding=\"utf-8\" standalone=\"yes\"?><Settings><Type>15</Type><Module>True</Module><Capacity>10</Capacity></Settings>");
    var settings = doc
							  .Elements("Settings")
							  .Select(x => new Settings
							  {
								  Type = (int.Parse(x.Elements("Type").First().Value)),
								  Module = bool.Parse(x.Elements("Module").First().Value),
								  Capacity = (int.Parse(x.Elements("Capacity").First().Value)),
							  })
							  .ToList();
