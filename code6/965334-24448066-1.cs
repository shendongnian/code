    public static IList<T> Flush<T>
    (this BlockingCollection<T> collection, int maxSize = int.MaxValue)
    {
         // Argument checking.
    
         T next;
         var result = new List<T>();
    
         while(result.Count < maxSize && collection.TryTake(out next))
         {
             result.Add(next);
         }
    
         return result;
    }
