    interface IDimension
    {
        double DistanceBetween(IDimension d);
    }
    
    public class Dimension<T> : IDimension
    {
        public T Data { get; private set; }
    
        public Dimension(T data)
        {
            Data = data;
        }
    
        public double DistanceBetween(Dimension<T> otherPoint)
        {
            return 0;
        }
    }
