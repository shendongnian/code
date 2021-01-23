    foreach(var prop in properties)
	{
		var propertyValue = prop.GetValue(myObj, null);
        if(propertyValue != null)
        {
		    var value = propertyValue.GetType().IsEnum
			    ? (propertyValue is MyEnum
				    ? YourClassWithExtensionMethod.GetTitle((MyEnum) propertyValue)
    				: ProcessGenericEnum(propertyValue))
	    		: propertyValue.ToString();
        }
	}
