    public interface InterfaceA
    {
        // Only expose what is of public interest!
        string Description { get; }
    }
    
    internal interface InterfaceAInternal : InterfaceA
    {
        string Data { get; }
    }
    
    public interface InterfaceB
    {
        InterfaceA DoStuff();
    }
    
    internal interface InterfaceC
    {
        IEnumerable<InterfaceAInternal> GetStuffThatHaveBeenDone();
    }
    public interface InterfaceD
    {
        IEnumerable<InterfaceA> GetStuffThatHaveBeenDone();
    }
