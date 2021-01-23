    Visibility vis;
    public Visibility Vis
	{
		get { return vis; }
		set
		{
			vis = value;
			imageLocationChanged();
			NotifyPropertyChanged("Vis");
		}
	}
	void imageLocationChanged()
	{
		//Do stuff
	}
