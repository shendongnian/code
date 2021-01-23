    private void UpdatePriceWithVat()
    {
        _priceWithVat = _price * (1 + _vat / 100);
        NotifyOfPropertyChange(() => PriceWithVat);
    }
    private void UpdatePrice()
    {
        _price = _priceWithVat / (1 + _vat / 100);
        NotifyOfPropertyChange(() => Price);
    }
    public decimal Price
    {
        get { return _price; }
        set
        {
            if (_price != value)
            {
                _price = value;
                NotifyOfPropertyChange(() => Price);
                UpdatePriceWithVat();
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
                UpdatePriceWithVat();
            }
        }
    }
    public decimal PriceWithVat
    {
        get { return _priceWithVat; }
        set
        {
            if (_priceWithVat != value)
            {
                _priceWithVat = value;
                NotifyOfPropertyChange(() => PriceWithVat);
                UpdatePrice();
            }
        }
    }
