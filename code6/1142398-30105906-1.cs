    // here's your model
    public class OrderAction
    {
        public string Name {get;set;}
    } 
    
    // here's your VM
    public class OrderActionViewModel
    {
    
        public ObservableCollection<OrderAction> Actions { get; private set; }
        // INotifyPropertyChanged implementation left off the following
        public OrderAction CurrentAction { get; set; } 
    }
