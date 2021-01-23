    private PropertyInfo FindMyProperty(Type type, string propertyName)
    {
        var result = type.GetProperty(propertyName);
        if (result == null)
        {
            foreach(var iface in type.GetInterfaces())
            {
                var ifaceProp = FindMyProperty(iface, propertyName);
                if (ifaceProp != null)
                    return ifaceProp;
            }
        }
        return result;
    }
