    class MyClass
    {
        public void Foo(ref int a)
        {
            a += a;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int intvalue = 3;
            var myClass = new MyClass();
            myClass.Foo(ref intvalue);
            Console.WriteLine(intvalue);    // Output: 6
        }
    }
