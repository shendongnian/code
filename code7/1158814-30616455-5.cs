    public class MyComparer : IComparer<int>
    {
        public MyClass Target;
        public int Compare(int x, int y)
        {
            return Target.Ascending ? x.CompareTo(y) : y.CompareTo(x);
        }
    }
