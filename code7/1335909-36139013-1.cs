    interface IEmbeddedPolicy<U>
    {
        void _doSomething(U u);
    }
    class MyClass<T> :
        IEmbeddedPolicy<double>,
        IEmbeddedPolicy<int>
    {
        public T Value { get; }
        public MyClass(T value) { this.Value = value; }
        void IEmbeddedPolicy<int>._doSomething(int u)
            => Console.WriteLine("this is T, int");
        void IEmbeddedPolicy<double>._doSomething(double u)
            => Console.WriteLine("this is T, double");
    }
    static class EmbeddedPolicyExtension
    {
        public static void doSomething<E, U>(this E embedded, U u)
            where E : IEmbeddedPolicy<U>
            => embedded._doSomething(u);
    }
