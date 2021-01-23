    IHasOperatingSystem<T> where T: IOperatingSystem 
    {
        TOperatingSystem { get; }
    } 
    
    Computer<T> : IHasOperatingSystem <T> where T : IOperatingSystem
    {
        public T OperatingSystem { get; }
    }
