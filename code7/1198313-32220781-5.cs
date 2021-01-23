    private object CreateObject(Type type)
    {
        var obj = Activator.CreateInstance(type);
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
                 property.SetValue(obj, this.CreateObject (property.PropertyType); 
            }
        }
        return obj;
    }
  
    private object CreatePrimitive(TypeCode typeCode)
    {
        switch (typeCode)
        {
            case TypeCode:Boolean:
                return this.rnd.Next(2) == 0;
            case TypeCode.Byte:
                return (Byte)this.rnd.Next(Byte.MinValue, Byte.MaxValue);
            case TypeCode.DateTime:
                long ticks = (long)((DateTime.MaxValue.Ticks - DateTime.MinValue.Ticks) * rnd.NextDouble() + DateTime.MinValue.Ticks);
                return new DateTime(ticks);
             // etc.
        }
        return obj;
    }
