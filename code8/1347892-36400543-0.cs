    public void IterateProperties(object foo)
    {
        Type type = foo.GetType();
    
        // public properties
        foreach (PropertyInfo propertyInfo in type.GetProperties())
        {
            if (propertyInfo.CanRead)
            {
                object fooPropertyValue = propertyInfo.GetValue(foo, null);
            }
        }
    }
