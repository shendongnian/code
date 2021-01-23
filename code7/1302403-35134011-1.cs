    public class itemsVM : baseViewModel
    {
        private item _selectedItem;
        private ObservableCollection<OrderVM> _orders;
        public ObservableCollection<OrderVM> Orders
        {
            get
            {
                if (SelectedItem != null)
                {
                    _orders = new ObservableCollection<OrderVM>();
                    foreach (Order ord in SelectedItem.Orders)
                    {
                        _orders.Add(new OrderVM { Order = ord });
                    }
                    return _orders;
                }
                else
                    return null;
            }
            set { _orders = value; }
        }
