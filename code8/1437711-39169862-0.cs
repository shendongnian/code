    public static class StringExtensions
    {
        public static TDest ConvertStringTo<TDest>(this string src)
        {
            if (src == null)
            {
                return default(TDest);
            }           
    
            return ChangeType<TDest>(src);
        }
    
        private static T ChangeType<T>(string value)
        {
            var t = typeof(T);
    
            // changed t.IsGenericType to t.GetTypeInfo().IsGenericType
            if (t.GetTypeInfo().IsGenericType && t.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                if (value == null)
                {
                    return default(T);
                }
    
                t = Nullable.GetUnderlyingType(t);
            }
    
            return (T)Convert.ChangeType(value, t);
        }
    }
