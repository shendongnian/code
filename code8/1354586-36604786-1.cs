    private string product;
    public string Product
    {
        get { return product; }
        set
        {
            if (product != value)
            {
                product = value;
                UpdateAvailableCosts();
                OnPropertyChanged(value);
            }
        }
    }
