    public static class ConvertHelper
        {
            public static T ConvertValue<T>(object value)
            {
                Type typeOfT = typeof(T);
                if (typeOfT.BaseType != null && typeOfT.BaseType.ToString() == "System.Enum")
                {
                    return (T)Enum.Parse(typeOfT, Convert.ToString(value));
                }
                if ((value == null || value == Convert.DBNull) && (typeOfT.IsValueType))
                {
                    return default(T);
                }
                if (value is IConvertible)
                {
                    return (T)Convert.ChangeType(value, typeOfT, new CultureInfo("en-GB"));
                }
    
                return (T)Convert.ChangeType(value, typeOfT);
            }
    }
