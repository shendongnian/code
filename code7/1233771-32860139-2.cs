    public class MyValueComparerById : IComparer<MyValue>
    {
        public int Compare(MyValue x, MyValue y)
        {
            var firstResult = x.Id.CompareTo(y.Id);        
            if (firstResult == 0)
            {
                // I'm assuming that MyValue has an additional string property named 'SomeName'
                return x.SomeName.CompareTo(y.SomeName);
            }
            return firstResult;
        }
    }
