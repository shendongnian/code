    public void SetPropertyValueToNull(object instance)
    {
        PropertyInfo prop = instance.GetType().GetProperty("LastName");
        prop.SetValue(instance, null, null); //We need this overload for .NET < 4.5
    }
