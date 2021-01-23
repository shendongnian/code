    public static class ObjectExtension
    {
        public static T GetValue<T>(this object obj)
        {
            var converter = TypeDescriptor.GetConverter(typeof(T));
    
            if (converter == null)
                return default(T);
    
            return (T)converter.ConvertFrom(obj);
        }
    }
