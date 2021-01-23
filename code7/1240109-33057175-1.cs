        ...
        static void Method(MyClass instance)
        {
            // instance variable holds reference to same object but it is different variable
            instance = new MyClass() { MyProperty = 10 };
        }
        static void Main(string[] args)
        {
            MyClass instance = new MyClass();
            Method(instance);
            Console.WriteLine(instance.MyProperty);
        }
