    namespace All
    {
        class X
        {
            public static void Read() { }
        }
        class Y
        {
            public static void Write() { }
        }
    }
    namespace A
    {
        namespace First
        {
            //use class X in namespace All here;
        }
    }
    namespace B
    {
        namespace Second
        {
            //use class Y in namespace All here;
            class MyClass
            {
                private All.X;   //HERE is the code
            }
        }
    }
