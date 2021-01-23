    [Flags]
    public enum Modalities
    {
        None = 0,
        ILT = 1 << 0,
        VILT = 1 << 1,
        HVILT = 1 << 2,
        Online = 1 << 3,
        Package = 1 << 4,
        Scheduled = ILT | VILT | HVILT,
        All = ~None
    }
