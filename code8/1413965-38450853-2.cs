    public static class MyExtensions
    {
        public static bool Contains(this string str, string value,  
                                                            StringComparison comparisonType)
        {
            return str.IndexOf(value, comparisonType) >= 0;
        }
    }
