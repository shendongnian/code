    private DetailsViewModel detailsManager;
	public DetailsViewModel DetailsManager
	{
		get { return detailsManager; }
		set
		{
			if (Equals(value, detailsManager)) return;
			detailsManager = value;
			OnPropertyChanged();
		}
	}
	public event PropertyChangedEventHandler PropertyChanged;
	[NotifyPropertyChangedInvocator] // Comment out if no R#
	protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
	{
		PropertyChangedEventHandler handler = PropertyChanged;
		if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
	}
