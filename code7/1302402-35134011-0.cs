     public class OrderVM : baseViewModel
    {
        public OrderVM()
        {   }
        private order _order;
        public order Order
        {
            get
            {
                return _order;
            }
            set
            {
                _order = value;
                NotifyPropertyChanged();
            }
        }
	public decimal Percentage
        {
            get
            {
                return (decimal)_order.Percentage; //Without passing the selectedOrder.Percentage like this, It doesn't work
            }
            set
            {
                _order.Percentage = value;
                NotifyPropertyChanged();
                calculate();
            }
        }
        public decimal Qty
        {
            get
            {
                return (decimal)_order.Qty;
            }
            set
            {
                _order.Qty = value;
                NotifyPropertyChanged();
                calculate();
            }
        }
        public decimal Total
        {
            get
            {
                return (decimal)_order.Total;
            }
            set
            {
                _order.Total = value;
                NotifyPropertyChanged();
            }
        }
        private void calculate()
        {
            _order.Total = _order.Price * _order.Qty;
            NotifyPropertyChanged("Total");
        }
     }
