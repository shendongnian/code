    private void EnumerateFields(Type type)
    {
        Type subType = type.GetGenericArguments()[0];
        PropertyInfo[] props = subType.GetProperties();
        foreach (PropertyInfo prp in props)
        {
            // your logic here
        }
    }
