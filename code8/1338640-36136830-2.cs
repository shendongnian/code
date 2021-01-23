        public override bool Equals(T x, T y) {
            if (x != null) {
                if (y != null) return ((object)x).Equals(y);
                return false;
            }
            if (y != null) return false;
            return true;
        }
 
        [Pure]
        public override int GetHashCode(T obj) {
            if (obj == null) return 0;
            return ((object)obj).GetHashCode();
        }
