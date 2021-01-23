    public static IDictionary<string, List<T>> Classify<T>(this IEnumerable<T> items, IDictionary<string, Predicate<T>> predicates)
    {
       var classifiedItems = new Dictionary<string, List<T>>(predicates.Count);
       foreach (var predicate in predicates)
       {
           classifiedItems.Add(predicate.Key, new List<T>()); 
       }
       foreach (var item in items)
       {
           foreach (var predicate in predicates)
           {
               if (predicate.Value(item))
               {
                   classifiedItems[predicate.Key].Add(item);
                   break;
                }
            }
        }
        return classifiedItems;
    }
