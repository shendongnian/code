    public class IntArrayEqualityComparer : IEqualityComparer<int[]>
    {
        public bool Equals(int[] a, int[] b)
        {
            return a.SequenceEqual(b);
        }
        public int GetHashCode(int[] a)
        {
            return a.Sum();
        }
    }
