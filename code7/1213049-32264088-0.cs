    private ObservableCollection<DataList> data;
    public ObservableCollection<DataList> Data
    {
        get { return data; }
        set 
        { 
            data = value;
            OnPropertyChanged("Data");
        }
    }
