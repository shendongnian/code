    public class BoundedQueue<T> : extends Queue<T>
    {
       private int _bound;
    
       public BoundedQueue<T>(int bound)
       {
           _bound = bound;
       }
       public override void Enqueue(T item)
       {
           if(this.Count >= _bound)
           {
                throw new IndexOutOfRangeException("limit reached");
                // If simply throwing an exception isn't cool, you can also do the following to pop off the oldest item:
                // base.Dequeue();
           }
           base.Enqueue(T);
       }
