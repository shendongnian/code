    public static class MyHelper
    {
        public string MyFilter(this string txt)
        {
            return txt.Replace("foo", "bar");
        }
    }
