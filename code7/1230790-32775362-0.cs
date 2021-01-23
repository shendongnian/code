    public interface IBar<T>
    {
        void Bar(T t);
    }
    public interface IFoo<A, B> : IBar<A>
    {
        void Bar(B b);
    }
