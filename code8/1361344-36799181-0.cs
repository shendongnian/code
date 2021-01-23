    abstract class MyBase<T>
    {
        public abstract string Name {get; set;}
        public abstract ObservableCollection<T> SubItems {get; set;}
    }
    
    class Real1 : MyBase<SomeClass>
    {
           public override string Name  {get; set;}
           public override ObservableCollection<SomeClass> SubItems {get; set;}
    }
    
    class Real2 : MyBase<SomeDifferentClass>
    {
           public override string Name {get; set;}
           public override ObservableCollection<SomeDifferentClass> SubItems  {get; set;}
    }
