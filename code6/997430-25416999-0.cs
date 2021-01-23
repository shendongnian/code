    class B : C { }
    class C { }
    class Test<T> where T : C
    { }
    
    class Program
    {
        static void Main()
        {
            Test<B> test = new Test<B>(); //CS0311
        }
    }
