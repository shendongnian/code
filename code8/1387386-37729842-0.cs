    void Main()
    {
      var list = new MyList();
      list.InsertAt(0, 'A');
      list.InsertAt(1, 'B');
      list.InsertAt(2, 'C');
      list.InsertAt(1, 'X');
      
      Console.WriteLine(string.Join(", ", list.Select(i => i.ToString())));
      
      list.RemoveAt(1);
      
      Console.WriteLine(string.Join(", ", list.Select(i => i.ToString())));
    }
    
    public unsafe struct list
    {
        public char x;
        public list* next;
    }
    
    public unsafe class MyList : IEnumerable<char>
    {
      list* first;
      list* last;
      int count;
          
      public int Count { get { return count; } }
      public bool IsEmpty() { return count == 0; }
      
      private void Remove(list* previous, list* current)
      {
        if (first == current) first = current->next;
        if (last == current) last = previous;
        if (previous != null) previous->next = current->next;
        
        Console.WriteLine
          (
            "Removing {0}, first {1}, last {2}, count {3}", 
            current->x, 
            first == null ? '-' : first->x, 
            last == null ? '-' : last->x,
            count
          );
        
        count--;
        Marshal.FreeHGlobal(new IntPtr(current));
      }
      
      public void RemoveAt(int index)
      {
        if (count < index || index < 0)
          throw new ArgumentOutOfRangeException("Index is out of range!");
        
        var current = first;
        
        if (index == 0)
        {
          Remove(null, current);
    
          return;
        }
    
        for (var i = 0; i < index - 1; i++)
        {
          current = current->next;
        }
        
        Remove(current, current->next);
      }
      
      ~MyList()
      { 
          do
          {
            RemoveAt(0);
          }
          while (!IsEmpty());
      }
      
      private list* InsertAfter(list* previousItem, char character)
      {   
        var newItem = (list*)Marshal.AllocHGlobal(sizeof(list));
        newItem->next = previousItem == null ? null : previousItem->next;
        newItem->x = character;
        
        if (previousItem == last) last = newItem;
        if (previousItem != null) previousItem->next = newItem;
        
        count++;
        
        Console.WriteLine
          (
            "Added {0} after {1}, first {2}, last {3}, count {4}",
            character,
            previousItem == null ? '-' : previousItem->x,
            first == null ? '-' : first->x,
            last == null ? '-' : last->x,
            count
          );
        
        return newItem;
      }
      
      public void InsertAt(int index, char character) 
      { 
        if (count < index || index < 0)
          throw new ArgumentOutOfRangeException("Index is out of range!");
    
        if (index == 0)
        {
          var newItem = InsertAfter(null, character);
          if (first != null) newItem->next = first;
          first = newItem;
        }
        else if (index == 1) 
        {
          InsertAfter(first, character);
        }
        else if (index == count) 
        {
          InsertAfter(last, character);
        }
        else
        {
          var current = first;
          for (var i = 0; i < index - 2; i++)
          {
            current = current->next;
          }
        
          InsertAfter(current, character);
        }
      }
      
      private class MyListEnumerator : IEnumerator<char>
      {
        private MyList list;
        private list* current;
      
        public MyListEnumerator(MyList list)
        {
          this.list = list;
          this.current = null;
        }
        
        public void Reset() { current = null; }
        
        public bool MoveNext()
        {
          if (current == null) current = list.first;
          else current = current->next;
          
          return current != null;
        }
        
        public char Current
        {
          get
          {
            if (current == null) throw new InvalidOperationException();
            
            return current->x;
          }
        }
        
        object IEnumerator.Current { get { return (object)Current; } }
        
        public void Dispose() {}
      }
      
      public IEnumerator<char> GetEnumerator() { return new MyListEnumerator(this); }
      IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
    }
