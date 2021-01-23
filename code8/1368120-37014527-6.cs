    //gets the value of myclass's car property--an array of type Car[] returned as an object
	var cars = c.GetType().GetProperty("car").GetValue(c, null);
	if (cars.GetType().IsArray)//should be true for you
	{
        //gets the type of the elements of the array: Car
		var carArrayElementType = cars.GetType().GetElementType();
        
        //gets the color property of Car
		var colorProp = carArrayElementType.GetProperty("color");
		//lets you loop through the cars array
        var carEnumerable = cars as IEnumerable;
		foreach (var car in carEnumerable)
		{
            //returns the color property's value as a string
			var color = colorProp.GetValue(car, null) as string;
			
           //use color
		}
	}
