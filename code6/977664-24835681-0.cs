        public EventModel(Guid id = 0, string name = "Default", DateTime startTime = new DateTime(0), DateTime endTime = new DateTime(0))
        : base(id, name)
    {
        StartTime = startTime;
        EndTime = endTime;
    }
