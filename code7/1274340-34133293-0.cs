    public class ViewModel : INotifyPropertyChanged
    { 
      public ViewModel() { Objects = new ObservableCollection<object>(); }
    
      public ObservableCollection<object> Objects { get;set; }
    }
