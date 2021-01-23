    public event PropertyChangedEventHandler PropertyChanged;
	private void NotifyPropertyChanged(string PropertyName = "")
	{
		if(PropertyChanged != null)
		{
			PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
		}
	}
	private IEnumerable<string> _oz;
	public IEnumerable<string> Oz
	{
		get
		{
			return _oz;
		}
		set
		{
			_oz = value;
			NotifyPropertyChanged("Oz");
        }
	}
