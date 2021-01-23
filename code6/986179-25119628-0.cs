    public class SomeClass : ObservableCollection<MotionElement>
    {
      public int Field1 {get; set:}
     
      public string Description {get; set;}
      // remove this since the class is now the collection.
      // public List<MyClass> CollectionOfObjects {get; set;}
    }
