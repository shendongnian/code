    static class Extensions
    {
        public static TReturn NCR<T, TReturn>(this T instance, Func<T, TReturn> getter)
            where T : class
            where TReturn : class
        {
            if (instance != null)
                return getter(instance);
            return null;
        }
    
        public static TReturn NCR<T, TReturn>(this T? instance, Func<T, TReturn> getter)
            where T : struct
            where TReturn : class
        {
            if (instance != null)
                return getter(instance.Value);
            return null;
        }
    
        public static TReturn? NCV<T, TReturn>(this T instance, Func<T, TReturn> getter)
            where T : class
            where TReturn : struct
        {
            if (instance != null)
                return getter(instance);
            return null;
        }
    
        public static TReturn? NCV<T, TReturn>(this T? instance, Func<T, TReturn> getter)
        where T : struct
        where TReturn : struct
        {
            if (instance != null)
                return getter(instance.Value);
            return null;
        }
    }
