    private JobTicker _selectedCustomer;
    public JobTicker SelectedCustomer {
        get { return _selectedCustomer; }
        set {
            _selectedCustomer = value;
            //  If you're not in C#6, use this instead:
            //OnPropertyChanged("SelectedCustomer");
            OnPropertyChanged(nameof(SelectedCustomer));
        }
    }
    //  Implement INotifyPropertyChanged
    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string propName)
    {
        var handler = PropertyChanged;
        if (handler != null)
        {
            handler(this, new PropertyChangedEventArgs(propName));
        }
    }
