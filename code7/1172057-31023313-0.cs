    public static class Helper
    {
        public static string MyExtract(this string s) 
        {
             Double temp = 0;
             return s.Split(',').First(str => Double.TryParse(str, out temp)); 
        }
    }
