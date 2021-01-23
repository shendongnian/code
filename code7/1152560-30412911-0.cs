    protected void raisePropertyChanged(string propertyName)
	{
		if (PropertyChanged != null)
			PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
	}
