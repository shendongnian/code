    public class AlphabeticPaginationComparer : IComparer<Tuple<char, int>>
    {
        public int Compare(Tuple<char, int> a, Tuple<char, int> b)
        {
            if (a.Item1 == b.Item1)
                return 0;
            //...
        }
    }
