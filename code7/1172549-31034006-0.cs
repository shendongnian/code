    public class MyPairedObjectComparer : IComparer<KeyValuePair<myCustomObject, int>>
    {
        public int Compare(KeyValuePair<myCustomObject, int> x,
            KeyValuePair<myCustomObject, int> y)
        {
            if (x.Key == null && y.Key == null)
                return 0;
            else if (x.Key == null)
                return -1;
            else if (y.Key == null)
                return 1;
            else
                return x.Key.b.CompareTo(y.Key.b);
        }
        private static MyPairedObjectComparer instance = new MyPairedObjectComparer();
        public static MyPairedObjectComparer Default { get { return instance; } }
    }
