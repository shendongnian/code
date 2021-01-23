	private double _Progress = 0;
	public double Progress
	{
		get { return _Progress; }
		set
		{
			if (value != _Progress)
			{
				_Progress = value;
				OnPropertyChanged("Progress");
			}
		}
	}
<!--->
    // Dummy updates, 10% every second
	new Thread(p =>
	{
		for (int i = 0; i < 10; i++)
		{
			Progress += 10;
			Thread.Sleep(1000);
		}
	}).Start();
