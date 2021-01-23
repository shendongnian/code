	const string json = @"
		{ 
			""coordinates"": 
			[
				[
					[-3.213338431720785, 55.940382588499197],
					[-3.213340490487523, 55.940381867350276],
					[-3.213340490487523, 55.940381867350276],
					[-3.213814166228732, 55.940215021175085],
					[-3.21413960035129, 55.940100842843712]
				]
			]
		}";
	var jsObject = JObject.Parse(json);
	/*
	 * 1. Read property "coordinates" of your root object
	 * 2. Take first element of array under "coordinates"
	 * 3. Select each pair-array and parse their values as doubles
     * 4. Make a list of it
	 */
	var result = jsObject["coordinates"]
					.First()
					.Select(pair => new Tuple<double, double> (
							pair[0].Value<double>(), 
							pair[1].Value<double>()
						)
					).ToList();
