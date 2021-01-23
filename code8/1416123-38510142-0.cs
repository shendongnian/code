    public class RangeFilter<T> : IFilter<T> 
        where T : struct, IConvertible, IComparable 
    {
    
        public T? Maximum { get; private set; }
        public T? Minimum { get; private set; }
    
        public RangeFilter(T maximum) 
        {
            Minimum = null;
            Maximum = maximum;
        }
    
    }
