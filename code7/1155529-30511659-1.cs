    public class Range : IReadOnlyList<int>
    {
        public int Start { get; private set; }
        public int Count { get; private set; }
        public int this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfBoundsException("index");
                }
                return Start + index;
            }
        }
        public Range(int start, int count)
        {
            this.Start = start;
            this.Count = count;
        }
        public IEnumerable<int> GetEnumerator()
        {
            return Enumerable.Range(Start, Count);
        }
        ...
    }
