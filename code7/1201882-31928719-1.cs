    public class TimeSeries<T, K>
    {
        public class Set<M> where M : TimeSeries<T, K>
        {
            public M SomeField;
        }
    }
