    public class CurrencyCodeComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            if (x == y)
                return 0;
            if (x == "USD")
                return -1;
            if (y == "USD")
                return 1;
            return x.CompareTo(y);
        }
    }
