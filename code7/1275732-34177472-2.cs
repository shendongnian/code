    public GoodClass(IClock clock)
    {
        this.clock = clock;
    }
    public GoodClass() : this(SystemClock.Instance)
    {
    }
