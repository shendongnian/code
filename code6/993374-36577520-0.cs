    public static T IntToEnum<T>(object value)
    {
        if (value == null)
            return (T)value;
        else if (typeof(T).IsEnum)
            return (T)value;
        else if (Nullable.GetUnderlyingType(typeof(T))?.IsEnum == true)
            return (T)Enum.ToObject(Nullable.GetUnderlyingType(typeof(T)), (int)value);
        throw new Exception(string.Format("Value cannot be converted from {0} to {1}", value.GetType().Name, typeof(T).Name));
    }
