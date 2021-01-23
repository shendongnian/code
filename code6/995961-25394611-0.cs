    public static class Extensions{
      public static IEnumerable<IGrouping<double, TValue>> FuzzyGroup<TValue>(
        this IEnumerable<TValue> source,
        double tolerance, 
        Func<TValue, double> keySelector) 
      {
        if(source == null)
          throw new ArgumentNullException("source");
          
        return FuzzyGroupHelper<TValue>.Group(source, tolerance, keySelector);
      }
      
      private static class FuzzyGroupHelper<TValue>
      {
        public static IEnumerable<IGrouping<double, TValue>> Group(
          IEnumerable<TValue> source,
          double tolerance, 
          Func<TValue, double> keySelector)
        {
          Node root = null, current = null;
          foreach (var item in source)
          {
            var key = keySelector(item);
            if(root == null) root = new Node(key);
            current = root;
            while(true){
              if(key < current.Min - tolerance) { current = (current.Left ?? (current.Left = new Node(key))); }
              else if(key > current.Max + tolerance) {current = (current.Right ?? (current.Right = new Node(key)));}
              else 
              {
                current.Values.Add(item);
                current.Max = current.Max < key ? key : current.Max;
                current.Min = current.Min > key ? key : current.Min;    
                break;
              }  
            }
          }
      
          foreach (var entry in InOrder(root))    
          {
            yield return entry;      
          }
        }
        
        private static IEnumerable<IGrouping<double, TValue>> InOrder(Node node)
        {
          if(node.Left != null)
            foreach (var element in InOrder(node.Left))
              yield return element;
          
          yield return node;
          
          if(node.Right != null)
            foreach (var element in InOrder(node.Right))
              yield return element;    
        }  
        
        private class Node : IGrouping<double, TValue>
        {
          public double Min;
          public double Max;
          public readonly List<TValue> Values = new List<TValue>();    
          public Node Left;
          public Node Right;
          
          public Node(double key) {
            Min = key;
            Max = key;
          }  
          
          public double Key { get { return Min; } }
          IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }    
          public IEnumerator<TValue> GetEnumerator() { return Values.GetEnumerator();  }  
        }
    }
