    namespace CustomExtensions
    {
     public static class StringExtension
     {
        private static char[] invalid = new char[] {' ','-','_','.'};
        public static string CleanString(this string y)
        {
          return new string(y.Where(x => !invalid.Contains(x)).ToArray()).ToLower();
        }
     }
    }
