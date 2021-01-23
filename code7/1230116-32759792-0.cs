    public object GetPropertyOfMyClass(string propertyName, MyClass instance)
    {
        System.Reflection.PropertyInfo[] properties = typeof(MyClass).GetProperties();
        return properties.Single(i => i.Name == "propertyName").GetValue(instance);
    }
