    public interface IHaveFirstItem { int FirstItem { get; set; } }
    public interface IHaveSecondItem { int SecondItem { get; set; } }
    
    public class A : IHaveFirstItem
    {
        public int FirstItem { get; set; }
    }
    
    public class B : IHaveSecondItem
    {
        public int SecondItem { get; set; }
    }
    
    public class AComparer : IEqualityComparer<A>
    {
        public bool Equals(A x, A y)
        {
             return (x.FirstItem == y.FirstItem);
        }
    
        public int GetHashCode(CoinDetails obj)
        {
            unchecked
            {
                  return obj.FirstItem;
            }
        }                      
    }
    
    public class IndexerImplementationUsingAandB
    {
        private IDictionary<A, B> _pairs = new Dictionary<A, B>(new BComparer());
    
        public this[int number]
        {
             get { return _pairs.First(x => x.FirstItem == number); }
             set { _pairs[new A() { FirstItem = number }] = value; }
        }
    }
