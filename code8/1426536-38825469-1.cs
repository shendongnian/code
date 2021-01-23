    public class MyClass
    {
        protected Foo()
        {
            // Do something
        }
    
        protected Bar()
        {
            // Do something else
        }
    }
    
    public class MyChildClass : MyClass
    {
        public MyChildClass(int x)
        {
            if(x > 0)
            {
                Foo();
            }
            else
            {
                Bar();
            }
        }
    }
