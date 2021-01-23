    // could have base class, may have to implement INotifyPropertyChanged, etc.
    public class ViewModelA { }
    public class ViewModelB
    {
        public string SomeProperty { get; }
    }
    ...
    
    public object SelectedViewModel { get; set; }
