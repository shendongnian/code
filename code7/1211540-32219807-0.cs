    void CompareCars(Car oldCar, Car newCar) 
    {
		Type type = oldCar.GetType();
		PropertyInfo[] properties = type.GetProperties();
		foreach (PropertyInfo property in properties)
		{
			object oldCarValue = property.GetValue(oldCar, null); 
			object newCarValue = property.GetValue(newCar, null); 
			Console.WriteLine("oldCar." + property.Name +": " + oldCarValue.toString() " -> "  + "newCar." + property.Name +": " newCarValue.toString();
		}
    }
