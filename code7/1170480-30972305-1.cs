    public static T GetCustomAttribute<T>(this Type type, bool inherit) where T : Attribute
    {
    	object[] attributes = type.GetCustomAttributes(inherit);
    	return attributes.OfType<T>().FirstOrDefault();
    }
