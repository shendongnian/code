    public class SomeClass : ObservableCollection<Elements>
    {
      private int _field1;
      public int Field1 
       {
        get
         {
          return _field1;
         }
        set
         {
          _field1 = value;
          OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
         }
       }
     
      private string _description;
      public string Description 
       {
        get
         {
          return _description;
         }
        set
         {
          _description= value;
          OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
         }
       }
      // remove this since the class is now the collection.
      // public List<MyClass> CollectionOfObjects {get; set;}
    }
