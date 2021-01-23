    public static class MinHeap
    {
        public static MinHeap<T,T> Create<T>(int capacity) where T : IComparable<T>
        {
            return new MinHeap<T,T>(capacity, x => x);
        }
    }
