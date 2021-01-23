    public class MegaList<T> : ObservableCollection<T>
    {
      // Initialize new instance of Gyrasoft.Common.MegaList<T> with elements from collection. 
      public MegaList(IEnumerable<T> collection)
         : base(collection) { }
      /// Adds the elements of specified collection in batch mode, fire event once after 
      public MegaList<T> AddRange(IEnumerable<T> collection)
      {
         foreach (var i in collection)
            Items.Add(i);
         OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
         return this;
      }
    }
