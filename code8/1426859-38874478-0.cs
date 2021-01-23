    public interface IComputation
    {
        IComputation Proxy { get; set; }
        // Other stuff
    }
    public interface IComputation<T> : IComputation where T : IComputation
    {
        new T Proxy { get; set; }
        // Other stuff
    }
