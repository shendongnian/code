    public class ViewModel : INotifyPropertyChanged
    {
        public ViewModel()
        {
            Order = new OrderEntity { Name = "someOrder",OrderNumber="my order", Quantity = 23 };
            Order.IsValidChanged += Order_IsValidChanged;
        }
        void Order_IsValidChanged()
        {
            if (SaveCommand != null)//RaiseCanExecuteChanged so that Save button disable on error 
                SaveCommand.RaiseCanExecuteChanged();
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
            get { return saveCommand ?? (saveCommand = new MyCommand(OnSave, () => Order != null && Order.IsValid)); }
        }
        void OnSave(object obj)
        {
            //Do save stuff here
        }
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertychanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
