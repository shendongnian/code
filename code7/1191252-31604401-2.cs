    interface MyInterface
    {
        void showData();
    }
    class MyClass : MyInterface
    {
        public void showData()
        {
            Console.WriteLine("MyClass");
        }
    }
    class MyClass2 : MyInterface
    {
        public void showData()
        {
            Console.WriteLine("MyClass2");
        }
    }
