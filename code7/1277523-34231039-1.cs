    public static string GetAllProperties(object obj)
    {
        return string.Join(" ", obj.GetType()
                                    .GetProperties()
                                    .Select(prop => prop.GetValue(obj)));
    }
