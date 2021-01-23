    public ObservableCollection<Family> Families
    {
        get { return _families; }
        set
        {
            _families= value;
            RaisePropertyChanged("Families");
        }
	}
    public ObservableCollection<Family> _families; 
    protected void RaisePropertyChanged(string propertyName)
    {
        PropertyChangedEventHandler handler = PropertyChanged;
        if (handler != null)
        {
            handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public event PropertyChangedEventHandler PropertyChanged;      
