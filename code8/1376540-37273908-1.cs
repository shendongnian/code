    private int _quantity;
    public int Quantity
    {
        get { return _quantity; }
        set
        {
            if (_quantity!=value)
            {
                _quantity = value;
                OnPropertyChanged();
                Total = Cost*Quantity
                OnPropertyChanged("Total");
            }
        }
    }
