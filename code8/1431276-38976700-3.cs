    public interface IB<out T> {
    //                  ^^^
    }
    // This works
    public interface IA<in TInput> {
        void Method(IB<TInput> x);
    }
    // This works too
    public interface IC<out TInput> {
        void Method(IB<TInput> x);
    }
