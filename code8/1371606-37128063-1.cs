    class IdentityEqualityComparer<T> : IEqualityComparer<T> where T : class {
        public bool Equals(T v1, T v2) {
            return object.ReferenceEquals(v1, v2);
        }
        public int GetHashCode(T v) {
            return RuntimeHelpers.GetHashCode(v);
        }
    }
