      public class OrdersVM : ViewModelBase
      {
        private Action<Order> _NavigateToOrderAction;
    
        private Order _SelectedOrder;
    
        public OrdersVM(Action<Order> navigateToOrderAction)
        {
          PropertyChanged += OrdersVM_PropertyChanged;
        }
    
        public Order SelectedOrder
        {
          get
          {
            return _SelectedOrder;
          }
          set
          {
            _SelectedOrder = value;
            OnPropertyChanged("SelectedOrder");
          }
        }
    
        private void OrdersVM_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
          if (e.PropertyName == "SelectedOrder")
            OnSelectedOrderChanged();
        }
    
        private void OnSelectedOrderChanged()
        {
          //Use Selected order and do something.
          _NavigateToOrderAction(SelectedOrder);
        }
      }
