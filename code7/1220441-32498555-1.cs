    private ObservableCollection<double> _testX;
    public ObservableCollection<double> TestX
    {
        get { return _testX; }
        set
        {
            if (value == _testX) return;
            _testX = value;
            OnPropertyChanged();
        }
    }
    
    private void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
	    var handler = PropertyChanged;
	    if (handler != null)
	    	handler(this, new PropertyChangedEventArgs(propertyName));
    }
