    public interface IPort
    {
        int Id { get; }
    }
    
    public interface IInternetPort : IPort
    {
        bool OfCapability(FiberCapability capability);
    }
