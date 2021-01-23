    private int _customerId;
    public int CustomerId
    {
        get
        {
             return _customerId;
        }
        set
        {
             if (_cusomterId != value)
             {
                  _customerId = value;
                  this.OnPropertyChanged();
             }
        }
    }
