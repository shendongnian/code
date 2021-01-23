    public static class MyExtentionClass
    {
        public static int WordCount(this string str)
        {
            var separators = new[] { ' ', '.', ',' };
            var count = str.Split(separators, StringSplitOptions.RemoveEmptyEntries).Length;
    
            return count;
        }
    }
