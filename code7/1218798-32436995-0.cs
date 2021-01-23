    public class FixedSizedQueue<T> : IEnumerable<T>
    {
        readonly ConcurrentQueue<T> _queue = new ConcurrentQueue<T>();
        int CountShadow = 0; // Counter for check constraints.
        public int Limit { get; set; }
    
        public FixedSizedQueue(int limit)
        {
            Limit = limit;
        }
    
        public void Enqueue(T obj)
        {
            /* Update shadow counter first for check constraints. */
            int count = CountShadow;
            while(true)
            {
                 if(count => Limit) return; // Adding element would violate constraint
                 int countOld = Interlocked.CompareExchange(ref CountShadow, count, count + 1);
                 if(countOld == count) break; //Successful update
                 count = countOld;
            }
            _queue.Enqueue(obj); // This will update real counter.
        }
        ...
    }
