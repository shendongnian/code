    internal class MyClass<T, U>
    {
        public MyClass(Func<T, U> arg)
        {
        }
        public MyClass(Func<Task<T>, U> arg)
        {
        }
    }
