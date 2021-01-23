    public string FindName<T>(Type type, T value)
    {
        EqualityComparer<T> c = EqualityComparer<T>.Default;
    
        foreach (FieldInfo  f in type.GetFields
                 (BindingFlags.Static | BindingFlags.Public))
        {
            if (f.FieldType == typeof(T) &&
                c.Equals(value, (T) f.GetValue(null)))
            {
                return f.Name; 
            }
        }
        return null;
    }
