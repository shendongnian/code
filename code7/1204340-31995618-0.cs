    internal class Program
    {
        public static void Main(string[] args)
        {
            new MyClass<double, double>(Method);
        }
        private static double Method(double d)
        {
            throw new NotImplementedException();
        }
    }
    internal class MyClass<T, U>
    {
        public MyClass(Func<U, T> arg)
        {
        }
        public MyClass(Func<U, Task<T>> arg)
        {
        }
    }
