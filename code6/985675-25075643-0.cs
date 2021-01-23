    public static Dictionary<string, object> ClassPropsToDictionary<T>(T classProps)
    {
        return classProps.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public).Where(pi => !pi.PropertyType.IsClass || pi.PropertyType == typeof(string))
                   .ToDictionary(prop => prop.Name, prop => prop.GetValue(classProps, null));
    }
