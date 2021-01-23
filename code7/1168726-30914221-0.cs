    public static object GetDefault(Type type)
    {
       if(type.IsValueType) return Activator.CreateInstance(type);
       return null;
    }
    foreach(var field in this.GetType().GetFields())
        field.SetValue(this, GetDefault(field.FieldType));
    foreach(var prop in this.GetType().GetProperties())
        prop.SetValue(this, GetDefault(prop.PropertyType));
