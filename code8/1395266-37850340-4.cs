    class MyComparer : IEqualityComparer<int[]> 
    {
        public int GetHashCode(int[] instance) { return 0; } // TODO: better HashCode for arrays
        public bool Equals(int[] instance, int[] other)
        {
            if (other == null || instance == null || instance.Length != other.Length) return false;
            return instance.SequenceEqual(other);
        }
    }
