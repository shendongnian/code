        public static class MyExtensions
        {
           public static int WordCount(this String str)
           {
               return str.Replace("\r", "\"\\r\"").Replace("\n", "\"\\n\"");
           }
        }
