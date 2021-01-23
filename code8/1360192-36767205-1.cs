    static class test
    {
        private static string Astring="static";
        public static void method(string Astring)
        {
            string staticField = Astring; // will be the passed value
            string passedString = test.Astring; //  will be static  
        }
    }
