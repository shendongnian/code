    public class MyGrandClass
    {
        public MyGrandClass(string name)
        {
            // Do something with the name.
        }
        public MyGrandClass()
        {
            // Do something else.
        }
    }
    public class MyClass : MyGrandClass
    {
        public MyClass(string name) : base(name)
        {
        }
        public MyClass()
        {
        }
    }
    
    public class MyChildClass : MyClass
    {
        public MyChildClass(string name) : base(name)
        {
        }
        public MyChildClass()
        {
        }
    }
