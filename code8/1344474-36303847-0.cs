    public static class MyExtensions
    {
        public static T ValueOrError<T>(this object val)
        {
            try
            {
                // http://stackoverflow.com/a/8633/2534462
                return (T)Convert.ChangeType(val, typeof(T));
            } catch
            {
                throw new Exception("Throw your own exception if you really want to");
            }
        }
        public static T ValueOrDefault<T>(this object val, T defaultValue)
        {
            try
            {
                return val.ValueOrError<T>();
            }
            catch
            {
                return defaultValue;  // usally use: return default(T);  
            }
        }
        public static T ValueOrNull<T>(this object val)
        {
            try
            {
                return val.ValueOrError<T>();
            }
            catch
            {
                // check for nullable type
                //https://msdn.microsoft.com/de-de/library/ms366789.aspx
                var type = typeof(T);
                if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    return default(T);  // null on nullable types
                } else {
                    throw new Exception("Callable only on Nullable types");
                    // my return another default value ???  .. -1 ???
                }
            }
        }
        public static T ValueDefaultValidated<T>(this object val, T defaultValue)
        {
            return val.ValueOrNull<T>() != null
                ? val.ValueOrError<T>()
                : val.ValueOrDefault<T>(defaultValue);
        }
    }
