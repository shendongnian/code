    public class ProducerConsumerSet<T> : IProducerConsumerCollection<T> {
      readonly object gate = new object();
    
      readonly Queue<T> queue = new Queue<T>();
    
      readonly HashSet<T> hashSet = new HashSet<T>();
    
      public void CopyTo(T[] array, int index) {
        if (array == null)
          throw new ArgumentNullException("array");
        if (index < 0)
          throw new ArgumentOutOfRangeException("index");
        lock (gate)
          queue.CopyTo(array, index);
      }
    
      public bool TryAdd(T item) {
        lock (gate) {
          if (hashSet.Contains(item))
            return false;
          queue.Enqueue(item);
          hashSet.Add(item);
          return true;
        }
      }
    
      public bool TryTake(out T item) {
        lock (gate) {
          if (queue.Count == 0) {
            item = default(T);
            return false;
          }
          item = queue.Dequeue();
          hashSet.Remove(item);
          return true;
        }
      }
    
      public T[] ToArray() {
        lock (gate)
          return queue.ToArray();
      }
    
      public void CopyTo(Array array, int index) {
        if (array == null)
          throw new ArgumentNullException("array");
        lock (gate)
          ((ICollection) queue).CopyTo(array, index);
      }
    
      public int Count {
        get { return queue.Count; }
      }
    
      public object SyncRoot {
        get { throw new NotSupportedException(); }
      }
    
      public bool IsSynchronized {
        get { return false; }
      }
    
      public IEnumerator<T> GetEnumerator() {
        return queue.GetEnumerator();
      }
    
      IEnumerator IEnumerable.GetEnumerator() {
        return GetEnumerator();
      }
    
    }
