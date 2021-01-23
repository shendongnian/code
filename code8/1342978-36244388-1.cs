    public class OrderLine : INotifyPropertyChanged
    {
        private decimal _qty;
        private decimal _cost;
    
        public decimal Qty
        {
            get { return _qty; }
            set
            {
                _qty = value; 
                OnPropertyChanged("Qty");
                OnPropertyChanged("CostExt");
            }
        }
    
        public decimal Cost
        {
            get { return _cost; }
            set
            {
                _cost = value;
                OnPropertyChanged("Cost");
                OnPropertyChanged("CostExt");
            }
        }
    
        public decimal CostExt
        {
            get
            {
                return Qty * Cost;
            }
        }
    
        #region Implementation of INotifyPropertyChanged
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    
        #endregion
    }
