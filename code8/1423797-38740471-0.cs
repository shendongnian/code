    class CustomComparer : IEqualityComparer<SomeClass>
    {
        public bool Equals(SomeClass x, SomeClass y)
        {
            // return true if equal
        }
        public int GetHashCode(SomeClass obj)
        {
            // return a hash code for boj
        }
    }
