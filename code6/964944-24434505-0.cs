    using RGiesecke.DllExport;
    
    namespace ClassLibrary1
    {
        public delegate int FooDelegate();
    
        public class Class1
        {
            [DllExport()]
            public static int Test(FooDelegate foo)
            {
                return foo();
            }
        }
    }
