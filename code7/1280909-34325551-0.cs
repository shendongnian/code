    class IntListComparer : IEqualityComparer<List<int>> {
        public bool Equals(List<int> x, List<int> y) {
            if (x == y)
                return true;
            if (x == null || y == null)
                return false;
            if (x.Length != y.Length)
                return false;
            using (var xenum = x.GetEnumerator()) {
                foreach (int yval in y) {
                    xenum.MoveNext();
                    if (yval != xenum.Current)
                        return false;
                }
            }
            return true;
        }
        // You also have to implement the GetHashCode which
        // must have the property that
        // if Equals(x, y) => GetHashCode(x) == GetHashCode(y)
        public int GetHashCode(List<int> x) {
            int hashcode = 1;
            const int primeMultiplier = 17;
            foreach (int xval in x)
                hashchode *= primeMultiplier * xval;
            return hashcode;
        }
    }
