    private decimal _someDecimal;
    public decimal SomeDecimal
    {
        get
        {
            return _someDecimal / 100;
        }
        set
        {
            _someDecimal = value * 100;
        }
    }
