    public double EndAngleValue
    {
        get
        {
            return _EndAngleValue;
        }
    
        set
        {
            SetProperty(ref _EndAngleValue, value);
    		OnPropertyChanged("EndAngleValue");
        }
    }
    
    private OnPropertyChanged(string propertyName)
    {
    	if(PropertyChanged != null)
    	{
    		PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    	}
    }
