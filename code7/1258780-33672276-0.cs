	public bool IsExpired
	{
		get { return _isExpired; }
		set
		{
			_isExpired = value;
			OnPropertyChanged("IsExpired");
		}
	}
