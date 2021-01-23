    public abstract class PrecisionSpace
    {
        private readonly double TOL;
        
        protected PrecisionSpace(double tol) { TOL = tol; }
    
        public bool TolEquals(double left, double right)
        {
            return (Math.Abs(left - right) <= TOL);
        }
    }
    
    public sealed class PerfectPrecision : PrecisionSpace
    {
        public PerfectPrecision() : base(0) { }
    }
    
    internal static class PrecisionSpaceCache<T> where T : PrecisionSpace, new()
    {
        public static readonly T Instance = new T();
    }
    
    public class MyVector<T> where T : PrecisionSpace, new()
    {
        public void Foo(double x, double y)
        {
            PrecisionSpaceCache<T>.Instance.TolEquals(x, y);
        }
    }
