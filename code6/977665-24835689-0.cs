    public EventModel(string name, DateTime startTime, DateTime endTime)
        : base(name)
    {
        Initialize(startTime, endTime);
    }
    public EventModel(Guid id, string name, DateTime startTime, DateTime endTime)
        : base(id, name)
    {
        Initialize(startTime, endTime);
    }
    private void Initialize(DateTime startTime, DateTime endTime)
    {
        StartTime = startTime;
        EndTime = endTime;
    }
