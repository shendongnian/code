    class FrobComparer : IComparer<Frob>
    {
        public int Compare(Frob x, Frob y)
        {
            int item1Comparison = x.Item1.CompareTo(y.Item1);
            if (item1Comparison == 0)
                return x.Item2.CompareTo(y.Item2);
            return item1Comparison;
        }
    }
