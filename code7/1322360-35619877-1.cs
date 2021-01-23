	private double _freq;
	public double Frequency
	{
		get { return _freq; }
		set { _freq = value; NotifyPropertyChanged( "Frequency" ); }
	}
    #region INotifyPropertyChanged Members
	public event PropertyChangedEventHandler PropertyChanged;
	#endregion
	protected void NotifyPropertyChanged( String info )
	{
		if ( PropertyChanged != null )
		{
			PropertyChanged( this, new PropertyChangedEventArgs( info ) );
		}
	}
