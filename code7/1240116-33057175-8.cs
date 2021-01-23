        class MyClass
        {            
            public int MyProperty { get; set; }
        }
        static void Method(MyClass instance)
        {
            instance.MyProperty = 10;                     
        }
        static void Main(string[] args)
        {
            MyClass instance = new MyClass();
            Method(instance);
            Console.WriteLine(instance.MyProperty);
        }
