    public public ObservableCollection<Family> Families
    {
        get { return _families; }
        set
        {
            _families= value;
            RaisePropertyChanged("Families");
        }
	}
    private string _families; 
       
