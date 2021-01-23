    class MyAwesomeProgram
    {
        private static void Main(string[] args)
        {
            string[] mystr = null;
            if (mystr.IsNullOrEmpty())
            {
                //Do your thing
            }
        }
    }
    static class Extensions
    {
        public static bool IsNullOrEmpty(this string[] strarray)
        {
            return strarray == null || strarray.Length < 1;
        }
    }
