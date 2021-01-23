    class PairComparer : IEqualityComparer<Pair>
    {
        public bool Equals(Pair x, Pair y)
        {
            return (x.Book1.Id == y.Book1.Id && x.Book2.Id == y.Book2.Id)
                || (x.Book1.Id == y.Book2.Id && x.Book2.Id == y.Book1.Id);
        }
        public int GetHashCode(Pair obj)
        {
            return obj.Book1.Id.GetHashCode() ^ obj.Book2.Id.GetHashCode();
        }
    }
