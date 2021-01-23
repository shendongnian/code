    public bool IsAmountZero
    {
        get { return Amount == 0; }
    }
    private int _amount;
    public int Amount
    {
        get { return _amount; }
        set
        {
            _amount = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(IsAmountZero));
        }
    }
