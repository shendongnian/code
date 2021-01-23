    public class Demo
    {
        public int ID { get; set; }
    }
    public class DemoComparer : IEqualityComparer<Demo>
    {
        public bool Equals(Demo x, Demo y)
        {
            if (Object.ReferenceEquals(x, y)) return true;
            if (x == null || y == null) return false;
            return x.ID == y.ID;
        }
        public int GetHashCode(Demo obj)
        {
            return obj.ID;
        }
    }
