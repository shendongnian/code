    public interface IChild
    {
        void Initialize(DomainHost host);
        void DoSomeChildishJob();
        string Name { get; }
    }
