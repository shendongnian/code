c#
    public class ToleranceEqualityComparer : IEqualityComparer<double>
    {
        public double Tolerance { get; set; } = 0.02;
        public bool Equals(double x, double y)
        {
            return x - Tolerance <= y && x + Tolerance > y;
        }
        
        //This is to force the use of Equals methods.
        public int GetHashCode(double obj) => 1;
    }
Which you should use like so
c#
 var dataByPrice = data.GroupBy(d => d.Price, new ToleranceEqualityComparer());
