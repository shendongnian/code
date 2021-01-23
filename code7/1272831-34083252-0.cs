    class MyTest : INotifyPropertyChanged, ISupportInitialize
    {
	public event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged;
	public delegate void PropertyChangedEventHandler(object sender, PropertyChangedEventArgs e);
	private bool _IsInitializing;
	private bool _MyProperty;
	public void BeginInit()
	{
		_IsInitializing = true;
	}
	public void EndInit()
	{
		_IsInitializing = false;
	}
	public bool MyProperty {
		get { return _MyProperty; }
		set {
			if (_MyProperty == value)
				return;
			_MyProperty = value;
			OnPropertyChanged("MyProperty");
		}
	}
	private void OnPropertyChanged(string propertyName)
	{
		if (_IsInitializing)
			return;
		if (PropertyChanged != null) {
			PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
    }
