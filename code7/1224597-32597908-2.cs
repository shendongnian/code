    private string _mySampleText;
	public string MySampleText
	{
		get { return _mySampleText; }
		set
		{
			if (value != _mySampleText)
			{
				_mySampleText = value;
				OnPropertyChanged("MySampleText");
			}
		}
	}
    ...
    protected void OnPropertyChanged(string passedValue)
	{
		var handler = PropertyChanged;
		if (handler != null)
			handler(this, new PropertyChangedEventArgs(passedValue));
	}
