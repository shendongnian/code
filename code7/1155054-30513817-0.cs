    public class PriorityQueue<T>
    {
        private List<T> dataHeap;
        private readonly IComparer<T> comp;
    
        public PriorityQueue() : this(Comparer<T>.Default) {}
    
        public PriorityQueue(IComparer<T> comp)
        {
            this.dataHeap = new List<T>();
            this.comp = comp;
        }
        ...
        private void BubbleUp() {
            if (this.comp.Compare(dataHeap[childIndex], dataHeap[parentIndex]) >= 0)
       }
    }
