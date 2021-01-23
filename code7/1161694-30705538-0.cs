    class BaseClass 
    {
        public void Foo() 
        {
            Console.WriteLine("BaseClass");
        }
    }
    class ChildClass : BaseClass 
    {
        public new void Foo()
        {
            Console.WriteLine("ChildClass");
        }
    }
    ChildClass obj1 = new ChildClass();
    BaseClass obj2 = obj1;
    obj1.Foo(); // Prints "ChildClass"
    obj2.Foo(); // Prints "BaseClass"
