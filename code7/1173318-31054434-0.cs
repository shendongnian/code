    void RemoveWithCancelation(this List<T> list, 
         Func<RemoveWithCancelationResult> predicate)
    {
       var indexToKeep = -1;
       
       for (var i = 0; i < list.Count; i++)
       {
          var condition = predicate(list[i]);
          if (condition.Cancel)
              break;
          if (!condition.RemoveItem)
          {
              indexToKeep++;
              list[indexToKeep] = list[i];
          }   
       }
       if (indexToKeep+1 < list.Count)
           list.RemoveRange(indexToKeep+1, list.Count);
    }
