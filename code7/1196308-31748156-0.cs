    namespace ExtensionMethods
        {
            public static class MyExtensions
            {
                public static void myMethod(this MyObject[] items)
                {
                    foreach(var item in items)
                    {
                       //do something;
                    }
                }
            }   
        }
