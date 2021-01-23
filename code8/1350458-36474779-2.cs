    public class Curve
    {
        public int CurveID { get; set; }
        public DateTime Timestamp { get; set; }
    }
    
    public class CurveGroup
    {
        public DateTime Timestamp { get; set; }
        public IEnumerable<Curve> Curves { get; set; }
    }
