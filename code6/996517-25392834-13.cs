        public class ViewModel : INotifyPropertyChanged
    {
        public ViewModel()
        {
            Order = new OrderEntity { Name = "someOrder",OrderNumber="my order", Quantity = 23 };
        }
        OrderEntity order;
        public OrderEntity Order
        {
            get { return order; }
            set { order = value; OnPropertychanged("Order"); }
        }
        MyCommand saveCommand;
        public MyCommand SaveCommand
        {
            get { return saveCommand ?? (saveCommand = new MyCommand(OnSave, () => Order != null)); }
        }
        //ValidateObject on Some button Command
        void OnSave(object obj)
        {
            Order.ValidateObject();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertychanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
