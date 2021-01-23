    static class test
    {
        private static string Astring="static";
        public static void method(string Astring)
        {
            string passedString = Astring; // will be the passed value
            string staticField = test.Astring; //  will be static  
        }
    }
