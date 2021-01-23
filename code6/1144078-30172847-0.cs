    public static class FooTracker
    {
        public static List<Action> AllBars = new List<Action>();
        public static void CallAllBars()
        {
            AllBars.ForEach(v => v());
        }
    }
    public static class Foo<T>
    {
        static Foo()
        {
            FooTracker.AllBars.Add(() => Bar());
        }
        public static void InitFoo() 
        { 
            // do nothing other than cause static constructor to run
        }
        private static T Baz;
        /* other members */
        public static void Bar()
        {
            //do something with Baz
            Debug.Print(typeof(T).Name);
        }
    }
