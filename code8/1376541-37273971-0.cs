    private decimal _total;
    private int _quantity;
    private decimal _cost
    
    public decimal Quantity
    {
       get { return _quantity; }
       set 
       {
           _quantity = value;
           Total = _quantity * _cost;
       }
    }
        public decimal Total
        {
            get { return _total; }
            set
            {
                if (_total != value)
                {
                    _total = value;
                    OnPropertyChanged();
                }
    
            }
        }
