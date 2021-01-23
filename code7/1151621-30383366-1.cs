    public class DataSeries<TDataPoint> : IDataSeries<TDataPoint>
        where TDataPoint : class, IDataPoint
    {
        // ...
        public IDataSeries<IDataPoint> GetUnsafeProxy ()
        {
            return new UnsafeProxy(this);
        }
        private class UnsafeProxy : IDataSeries<IDataPoint>
        {
            private readonly DataSeries<TDataPoint> _owner;
            public UnsafeProxy (DataSeries<TDataPoint> owner)
            {
                _owner = owner;
            }
            public object Source
            {
                get { return _owner.Source; }
            }
            public int Count
            {
                get { return _owner.Count; }
            }
            public double GetValue (int index)
            {
                return _owner.GetValue(index);
            }
            public DateTime GetTimeStampLocal (int index)
            {
                return _owner.GetTimeStampLocal(index);
            }
            public IDataPoint GetDataPoint (int index)
            {
                return _owner.GetDataPoint(index);
            }
            public IDataPoint GetLastDataPoint ()
            {
                return _owner.GetLastDataPoint();
            }
            public void Add (IDataPoint dataPoint)
            {
                _owner.Add((TDataPoint)dataPoint);
            }
            public IDataSeries<IDataPoint> Branch (object source)
            {
                return (IDataSeries<IDataPoint>)_owner.Branch(source);
            }
        }
