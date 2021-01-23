    public class PerfectPrecision : Precision<PerfectPrecision>
    {
        protected override double TOL
        {
            get { return 0.00f; }
        }
    }
    public class MyPrecision : Precision<MyPrecision>
    {
        protected override double TOL
        {
            get { return 0.01f; }
        }
    }
