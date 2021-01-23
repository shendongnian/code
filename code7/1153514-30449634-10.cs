     public IEnumerator<T> GetEnumerator()
      {
       var node = start;
       while(node != null)
       {
        yield return node.info;
        node = node.next;
     }
    }
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
     return GetEnumerator();
    }
    
