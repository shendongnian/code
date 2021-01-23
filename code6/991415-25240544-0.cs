    public static class Foo
    {
        private static object lockingObject = new object();
    
        public static void DoSomething()
        {
            lock (lockingObject)
            {
                // Do your stuff.
            }
        }
    }
