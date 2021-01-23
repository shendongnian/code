    private double totalValue;
    public double TotalValue
    {
        get { return totalValue; }
        set
        {
            totalValue = value;
            OnPropertyChanged("TotalValue");
        }
    }
