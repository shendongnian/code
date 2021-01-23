    static class test
        {
            private static string StaticAstring="static";
            public static void method(string passedAstring)
            {
                string staticField = StaticAstring; // will be static 
                string passedString = passedAstring; // will be the passed value  
            }
        }
