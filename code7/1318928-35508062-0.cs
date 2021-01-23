    public static void SetValue(object obj, string name, object value)
    {
        string[] parts = name.Split('.');
        if (parts.Length == 0)
        {
            throw new ArgumentException("name");
        }
        PropertyInfo property = null;
        FieldInfo field = null;
        object current = obj;
        for (int i = 0; i < parts.Length; i++)
        {
            if (current == null)
            {
                throw new ArgumentNullException("obj");
            }
            string part = parts[i];
            Type type = current.GetType();
            property = type.GetProperty(part, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            if (property != null)
            {
                field = null;
                if (i + 1 != parts.Length)
                {
                    current = property.GetValue(current);
                }
                continue;
            }
            field = type.GetField(part, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            if (field != null)
            {
                property = null;
                if (i + 1 != parts.Length)
                {
                    current = field.GetValue(current);
                }
                continue;
            }
            throw new ArgumentException("name");
        }
        if (current == null)
        {
            throw new ArgumentNullException("obj");
        }
        if (property != null)
        {
            property.SetValue(current, value);
        } 
        else if (field != null)
        {
            field.SetValue(current, value);
        }
    }
