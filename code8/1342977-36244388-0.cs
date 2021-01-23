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
