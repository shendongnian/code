    static class MyClassExtension
    {
        public static void nonWorkingExtension<T, U>(this MyClass<T, U> p, U u)
        {
            T Element = p.myEement;
            //Do something with u and p.Element
        }
    }
