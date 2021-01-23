    public static class Helper
    {
        public static int MyCount<T>(this IEnumerable<T> collection, Func<T, bool> function)
        {            
            int count = 0;
            foreach (T i in collection)
                if (function(i)) ++count;
            return count;
        }
    }
