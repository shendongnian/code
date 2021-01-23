    public class ViewModel : INotifyPropertyChanged
    {
      private Data _data = new Data();
    
      private ObservableCollection<Order> _orders;
      public ObservableCollection<Order> Orders
      {
        get { return _orders; }
        set
        {
          _orders = value;
          OnPropertyChanged("Orders");
        }
      }
      
      //define a constructor
      public ViewModel()
      {
        _data.Set<Order>().Load();
        this.Orders=_data.Set<Order>().Local;
      }
     //...
    }
