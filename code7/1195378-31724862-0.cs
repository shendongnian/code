    class MyClass
    {
        public string Name { get; set; }
        public int[] Array { get; set; }
    }
    class ArrayComparer : IEqualityComparer<int[]>
    {
        public bool Equals(int[] x, int[] y)
        {
            return x.SequenceEqual(y);
        }
        public int GetHashCode(int[] obj)
        {
            return string.Join(",", obj).GetHashCode();
        }
    }
