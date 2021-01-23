    public class F1
    {
        public readonly int k1;
        public readonly ImmutableList<int> k2;
        public F1(int k)
        {
            ...
        }
        private F1(int k1, ImmutableList<int> k2)
        {
            this.k1 = k1;
            this.k2 = k2;
        }
        public int GetItem(int pos)
        {
            return k2[pos];
        }
        public F1 SetItem(int pos, int val)
        {
            return new F1(k1, k2.SetItem(pos, val));
        }
    }
