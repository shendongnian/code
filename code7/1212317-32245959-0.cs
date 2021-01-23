    private void DisplayObject(object obj)
    {
        var type = obj.GetType();
        foreach(var propertyInfo in type.GetProperties())
        {
            object value = propertyInfo.GetValue(obj, null);
            if(propertyInfo.PropertyType.IsGenericType && 
                propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(IEnumerable<>))
            {
                foreach(object o in (IEnumerable)value)
                {
                    DisplayObject(o);
                }
            }
            else
            {
                Console.WriteLine(value);
            }
        }
    }
