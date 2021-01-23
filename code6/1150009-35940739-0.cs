    class OutputStack<T> : Stack<T>
    {
       public event EventHandler OnAdd;
       public void Push(T item)
       {
           base.Push(item);
           if (null != OnAdd) OnAdd(this, null);
       }
    } 
