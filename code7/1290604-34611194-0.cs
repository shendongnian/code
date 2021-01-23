     public static class MyClass
    {
        private static object _obj;
        private static bool flag;
        static MyClass()
        {
            
            if (!flag) {
                DoSomething();
                flag = true;
            }
        }
        private static void DoSomething()
        {
        }
        public static void DoSomething2()
        {
        }
    }
