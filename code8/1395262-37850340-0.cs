    class MyComparer : IEqualityComparer<int[]> 
    {
        public int GetHashCode() { return 0; } // TODO: better HashCode for arrays
        public bool Equals(int[] other)
        {
            if (other == null) return false;
            return this.SequenceEqual(other);
        }
    }
