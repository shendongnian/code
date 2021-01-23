    class IWillNotifyYou : INotifyPropertyChanged
    {
    	private int _firstProperty;
    	public int FirstProperty
    	{
    		get { return _firstProperty; }
    		set
    		{
    			if (value != _firstProperty)
    			{
    				_firstProperty = value;
    				OnPropertyChanged("FirstProperty");
    			}
    		}
    	}
    
    	private string _secondProperty;
    	public string SecondProperty
    	{
    		get { return _secondProperty; }
    		set
    		{
    			if (value != _secondProperty)
    			{
    				_secondProperty = value;
    				OnPropertyChanged("SecondProperty");
    			}
    		}
    	}
    
    	private void OnPropertyChanged(string propertyName)
    	{
    		if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    	}
    
    
    	public event PropertyChangedEventHandler PropertyChanged;
    }
