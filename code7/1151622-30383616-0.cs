    // here's the covariant, read-only part of the interface declaration
    public interface IReadOnlyDataSeries<out TDataPoint> where TDataPoint : class, IDataPoint {
        object Source { get; }
        int Count { get; }
        double GetValue(int index);
        DateTime GetTimeStampLocal(int index);
        TDataPoint GetDataPoint(int index);
        TDataPoint GetLastDataPoint();
    }
    // add a few bits to the read-write fully-typed interface, breaking covariance,
    // but being able to implicitly cast to the covariant readonly version when needed
    public interface IDataSeries<TDataPoint> : IReadOnlyDataSeries<TDataPoint> where TDataPoint : class, IDataPoint {
        void Add(TDataPoint dataPoint);
        IDataSeries<TDataPoint> Branch(object source);
    }
