    public class MyClassFactory
    {
        public MyClass Create(int value)
        {
            return new MyClass(value);
        }
    }
    public class MyClass
    {
        internal MyClass(int value)
        {
        }
        public void MethodA() { }
        public void MethodB() { }
    }
