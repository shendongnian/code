    IHasOperatingSystem<T> where T: IOperatingSystem 
    {
        T OperatingSystem { get; }
    } 
    
    Computer<T> : IHasOperatingSystem <T> where T : IOperatingSystem
    {
        public T OperatingSystem { get; }
    }
