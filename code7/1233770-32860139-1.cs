    public class MyValueComparerById : IComparer<MyValue>
    {
        public int Compare(MyValue x, MyValue y)
        {
             return x.Id.CompareTo(y.Id);        
        }
    }
