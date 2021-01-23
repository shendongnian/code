	public static List<string> getFieldData(List<DataField> dataToSearch, string fieldName)
	{
		// You can use reflection to get information from types at runtime.
		// The property_info variable will hold various data about the field
		// name you pass in (type, name, etc)
		var property_info = typeof(DataField).GetProperty(fieldName);
		// We can then call property_info's GetValue() on an instantiated 
		// object of our class, and it will return the value of that property on that object
		return dataToSearch.Select(ds => Convert.ToString(property_info.GetValue(ds))).Distinct().ToList();
	}
