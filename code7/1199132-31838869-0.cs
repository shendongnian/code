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
        Data.Set<Order>().Load();
        this.Orders=Data.Context.Set<Order>().Local;
      }
     //...
    }
