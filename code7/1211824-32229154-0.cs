    using PropertyChanged;
    ...
    [ImplementPropertyChanged]
    public class MyClass
    {
      public object Object {get;set;} 
    // INotifyPropertyChanged implemented automatically @ compile-time
    }
