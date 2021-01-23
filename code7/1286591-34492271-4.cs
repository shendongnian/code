    public decimal Price
    {
        get { return _price; }
        set
        {
            if (_price != value)
            {
                _price = value;
                NotifyOfPropertyChange(() => Price);
                NotifyOfPropertyChange(() => PriceWithVat);
            }
        }
    }
    
    public decimal Vat
    {
        get { return _vat; }
        set
        {
            if (_vat != value)
            {
                _vat = value;
                NotifyOfPropertyChange(() => Vat);
                NotifyOfPropertyChange(() => PriceWithVat);
            }
        }
    }
    public decimal PriceWithVat
    {
        get { return _price / (1 + _vat / 100); }
    }
