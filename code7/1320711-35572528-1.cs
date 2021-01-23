	public void Update()
	{
		foreach (var entry in this.Entries)
		{
			entry.LastUpdated = DateTime.Now;
		}
		
		if (this.PropertyChanged!= null)
		{
			PropertyChanged(this, new PropertyChangedEventArgs("Entries"));
		}
	}
