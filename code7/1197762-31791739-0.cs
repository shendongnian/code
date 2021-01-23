      internal class Grouping : IGrouping<TKey, TElement>, IList<TElement> {
        ...
        internal int count;      
        ...
        // No overhead in such implementation
        int ICollection<TElement>.Count {
          get { return count; }
        }
        ...
      }
