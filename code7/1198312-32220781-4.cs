    public T CreateObject<T>() where T: class, new()
    {
        var obj = Activator.CreateInstance<T>();
        foreach (var property in typeof(T).GetProperties()
            .Where(property => property.CanWrite))
        {
            if (property.PropertyType.IsPrimitive)
            {
                property.SetValue(obj, this.CreatePrimitive 
                   (Type.GetTypeCode(property.PropertyType)));
            }
            else if (property.PropertyType.IsClass)
            {
                 property.SetValue(obj, this.CreatObject...
  
