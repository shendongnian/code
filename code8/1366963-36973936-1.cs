    public class BoundedQueue<T> : Queue<T>
    {
       private readonly int _bound;
       public BoundedQueue(int bound)
       {
           _bound = bound;
       }
       public new void Enqueue(T item)
       {
           if(Count >= _bound)
           {
                throw new IndexOutOfRangeException("limit reached");
                // If simply throwing an exception isn't cool, you can also do the following to pop off the oldest item:
                // base.Dequeue();
           }
           base.Enqueue(item);
       }
    }
