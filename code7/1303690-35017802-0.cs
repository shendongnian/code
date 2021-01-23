    public BindableCollection<Market> Markets
    {
        get { return _MarketService.Markets; }
        set
        {
            if (_MarketService.Markets != value)
            {
                _MarketService.Markets = value;
                NotifyOfPropertyChange(() => Markets);
            }
        }
    }
