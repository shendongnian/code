    var result = matches.Distinct(new EqualityComparer());
    class EqualityComparer : IEqualityComparer<Matches> {
        public bool Equals(Matches m1, Matches m2) { return m1.OrderId == m2.MatchedOrderId && m2.OrderId == m1.MatchedOrderId ; }
        public int GetHashCode(Matches m) { return 17 * m.OrderId.GetHashCode() + m.MatchOrderId.GetHashCode(); }
    }
