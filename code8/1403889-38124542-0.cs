    public static bool IsPropertyNull(dynamic obj, string propertyName)
    {
    	var path = propertyName.Split('.');
    	object tempObject = obj;
    	for (int i = 0; i < path.Length; i++)
    	{
    		PropertyInfo[] dynamicProperties = tempObject.GetType().GetProperties();
    		var property = dynamicProperties.Single(x => x.Name == path[i]);
    		tempObject = property.GetValue(tempObject);
    	}
    	return tempObject == null;
    }
    bool isTitleNull = IsPropertyNull(result, "Title");
    bool cityNameNull = IsPropertyNull(result, "City.Name");
