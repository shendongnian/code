    public static T GetCustomAttribute<T>(this Type type) where T : Attribute
    {
        // Send inherit as false if you want the attribute to be searched only on the type. If you want to search the complete inheritance hierarchy, set the parameter to true.
    	object[] attributes = type.GetCustomAttributes(false);
    	return attributes.OfType<T>().FirstOrDefault();
    }
