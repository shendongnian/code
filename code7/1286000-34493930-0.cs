	public string LoginString
	{
		get
		{
			return _loginString;
		}
		set
		{
			if (_loginString == value)
			{
				return;
			}
			_loginString = value;
			RaisePropertyChanged(() => LoginString);
		}
	}
