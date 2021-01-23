    public static object GetPropertyValue(this object myProperty, string propertyName)
    {
        return myProperty.GetType().GetProperties()
           .Single(pi => pi.Name == propertyName)
           .GetValue(myProperty, null);
    }
