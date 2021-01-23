    public void SetPropertyValueToNull(object instance)
    {
        PropertyInfo prop = instance.GetType().GetProperty("LastName");
        prop.SetValue(instance, null);
    }
