    class MyAwesomeProgram
    {
        private static void Main(string[] args)
        {
            string[] mystr = null;
            if (mystr.IsNullOrEmpty())
            {
                //Do what you want
            }
        }
    }
    static class Extensions
    {
        public static bool IsNullOrEmpty(this string[] strarray)
        {
            return strarray == null || strarray.Length == 0;
        }
    }
