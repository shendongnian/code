    interface ISomePolicy<T, U>
    {
        void _doSomething(T t, U u);
    }
    struct SomePolicyImplementation :
        ISomePolicy<int, double>,
        ISomePolicy<int, int>,
        ISomePolicy<double, double>
    {
        void ISomePolicy<int, int>._doSomething(int t, int u)
            => Console.WriteLine("this is int, int");
        void ISomePolicy<int, double>._doSomething(int t, double u)
            => Console.WriteLine("this is int, double");
        void ISomePolicy<double, double>._doSomething(double t, double u)
            => Console.WriteLine("this is double, double");
    }
    static class SomePolicyExtension
    {
        public static void doSomething<P, T, U>(this P policy, T t, U u)
            where P : struct, ISomePolicy<T, U>
            => policy._doSomething(t, u);
    }
