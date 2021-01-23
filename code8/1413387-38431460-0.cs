    private ObservableCollection<ReaderViewModel> masters;
    public ObservableCollection<ReaderViewModel> Masters
    { 
        get
        {
            return masters;
        }
        set
        {
            masters = value;
            OnPropertyChanged("Masters");
        }
    }
    protected void OnPropertyChanged(String propertyName)
    {
        if (this.PropertyChanged != null)
            this.PropertyChanged(this,
                new PropertyChangedEventArgs(propertyName));
    }
