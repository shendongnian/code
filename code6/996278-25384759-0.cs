    public interface IJobBase
    {
        TimeSpan Interval { get; set; }
        DateTimeOffset StartTime { get; set; }
        int Priority { get; set; }
        bool Repeat { get; set; }
        bool Enabled { get; set; }
    }
    
    public interface IJob : IJobBase
    {
        void Trigger();
    }
    
    public interface IJob<out T> : IJobBase
    {
        T Trigger();
    }
