    public Customer Customer //read only
    {
        get { return customer; }
        private set {
            if (value != customer)
            {
                customer = value;
                OnPropertyChanged("Customer");
            }
        }
    }
