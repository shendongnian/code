    public void CreateFullInstance(object obj)
    {
        PropertyInfo[] properties = obj.GetType().GetProperties();
        foreach(var property in properties)
        {
            Type propertyType = property.PropertyType;
            if(!propertyType.IsPrimitive && 
            propertyType.GetConstructor(Type.EmptyTypes) != null)
            {
                var val = Activator.CreateInstance(propertyType);
                property.SetValue(obj,val);
                CreateFullInstance(val);
            }
        }
    }
