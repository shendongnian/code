	var cars = c.GetType().GetProperty("car").GetValue(c, null);
	if (cars.GetType().IsArray)
	{
		var carArrayType = cars.GetType().GetElementType();
		var colorProp = carArrayType.GetProperty("color");
		var carEnumerable = cars as IEnumerable;
		foreach (var car in carEnumerable)
		{
			var color = colorProp.GetValue(car, null) as string;
			//use color
		}
	}
