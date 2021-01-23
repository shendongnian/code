    private ObservableCollection<LoadData> items; 
    public ObservableCollection<LoadData> Items
    {
        get { return items; }
        set { items = value; NotifyPropertyChanged("Items"); }
    }
    // Implement INotifyPropertyChanged interface here!!
