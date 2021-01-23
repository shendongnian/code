    public class DuplicateKeyComparer<TKey> : IComparer<TKey> where TKey : IComparable
    {
        public int Compare(TKey x, TKey y)
        {
            var res = x.CompareTo(y);
            return res == 0 ? 1 : res;
        }
    }
