    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown),
     Guid("example-0000-0000-0000-0000000000000")]
    public interface ILogger
    {
        void WriteLine(string line); 
    }
