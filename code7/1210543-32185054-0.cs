    class Program
    {
        static void Main(string[] args)
        {
            var obj = new MyClass();
            //obj.SetThis().SetThat().SetThisThirdThing().setThisFourthThing(); // Compile error
            obj.SetThis().SetThat().Cast<MyClass>().SetThisThirdThing().setThisFourthThing();
        }
    }
    class SuperClass
    {
        public SuperClass SetThat()
        {
            return this;
        }
        public T Cast<T>() where T : SuperClass
        {
            return (T)this;
        }
    }
    class MyClass : SuperClass
    {
        public MyClass SetThis()
        {
            return this;
        }
        public MyClass SetThisThirdThing()
        {
            return this;
        }
        public MyClass setThisFourthThing()
        {
            return this;
        }
    }
