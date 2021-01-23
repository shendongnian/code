    public class LinkedRingBuffer<T>
    {
        private LinkedRingBufferNode<T> firstNode;
        private LinkedRingBufferNode<T> lastNode;
        private object Synchro;
        public LinkedRingBuffer(int capacity)
        {
            Synchro = new object();
            Capacity = capacity;
            Count = 0;
        }
        /// <summary>
        /// Maximum count of items inside the buffer
        /// </summary>
        public int Capacity { get; }
        /// <summary>
        /// Actual count of items inside the buffer
        /// </summary>
        public int Count
        {
            get
            {
                lock (Synchro)
                {
                    return _count;
                }
            }
            private set
            {
                _count = value;
            }
        }
        private int _count;
        /// <summary>
        /// Get value of the oldest buffer entry
        /// </summary>
        /// <returns></returns>
        public T GetFirst()
        {
            lock (Synchro)
            {
                return firstNode.Item;
            }
        }
        /// <summary>
        /// Get value of the newest buffer entry
        /// </summary>
        /// <returns></returns>
        public T GetLast()
        {
            lock (Synchro)
            {
                return lastNode.Item;
            }
        }
        /// <summary>
        /// Add item at the end of the buffer. 
        /// If capacity is reached the link to the oldest item is deleted.
        /// </summary>
        public void Add(T item)
        {
            lock (Synchro)
            {
                /* create node and set to last one */
                var node = new LinkedRingBufferNode<T>(lastNode, item);
                lastNode = node;
                /* if it is the first node, the created is also the first */
                if (firstNode == null)
                    firstNode = node;
                /* check for capacity reach */
                Count++;
                if (Count > Capacity)
                {
                    /* deleted all links to the current first so that its eventually gc collected */
                    Count = Capacity;
                    firstNode = firstNode.NextNode;
                    firstNode.PreviousNode = null;
                }
            }
        }
        /// <summary>
        /// Iterate through the buffer from the oldest to the newest item
        /// </summary>
        public IEnumerable<T> LastToFirst()
        {
            lock (Synchro)
            {
                var materialized = LastToFirstInner().ToList();
                return materialized;
            }
        }
        private IEnumerable<T> LastToFirstInner()
        {
            var current = lastNode;
            while (current != null)
            {
                yield return current.Item;
                current = current.PreviousNode;
            }
        }
        /// <summary>
        /// Iterate through the buffer from the newest to the oldest item
        /// </summary>
        public IEnumerable<T> FirstToLast()
        {
            lock (Synchro)
            {
                var materialized = FirstToLastInner().ToList();
                return materialized;
            }
        }
        private IEnumerable<T> FirstToLastInner()
        {
            var current = firstNode;
            while (current != null)
            {
                yield return current.Item;
                current = current.NextNode;
            }
        }
        /// <summary>
        /// Iterate through the buffer from the oldest to given item. 
        /// If item doesn't exist it iterates until it reaches the newest
        /// </summary>
        public IEnumerable<T> LastToReference(T item)
        {
            lock (Synchro)
            {
                var materialized = LastToReferenceInner(item).ToList();
                return materialized;
            }
        }
        private IEnumerable<T> LastToReferenceInner(T item)
        {
            var current = lastNode;
            while (current != null)
            {
                yield return current.Item;
                if (current.Item.Equals(item))
                    break;
                current = current.PreviousNode;
            }
        }
        /// <summary>
        /// Iterate through the buffer from the newest to given item. 
        /// If item doesn't exist it iterates until it reaches the oldest
        /// </summary>
        public IEnumerable<T> FirstToReference(T item)
        {
            lock (Synchro)
            {
                var materialized = FirstToReferenceInner(item).ToList();
                return materialized;
            }
        }
        private IEnumerable<T> FirstToReferenceInner(T item)
        {
            var current = firstNode;
            while (current != null)
            {
                yield return current.Item;
                if (current.Item.Equals(item))
                    break;
                current = current.PreviousNode;
            }
        }
        /// <summary>
        /// Represents a linked node inside the buffer and holds the data
        /// </summary>
        private class LinkedRingBufferNode<A>
        {
            public LinkedRingBufferNode(LinkedRingBufferNode<A> previousNode, A item)
            {
                Item = item;
                NextNode = null;
                PreviousNode = previousNode;
                if (previousNode != null)
                    previousNode.NextNode = this;
            }
            internal A Item { get; }
            internal LinkedRingBufferNode<A> PreviousNode { get; set; }
            internal LinkedRingBufferNode<A> NextNode { get; private set; }
        }
    }
