	public InnerControlViewModel()
	{
		if (IsInDesignMode)
		{
			MyCol = new ObservableCollection<string>() {"You are in design mode", "Next items are randomly generated:", " "};
		}
		else
		{
			MyCol = new ObservableCollection<string>() { "You are in runtime mode", "Next items are randomly generated:", " " };
		}
		for (int i = 0; i < 30; i++)
		{
			MyCol.Add("Random Date: " + RandomHelper.RandomDate());
		}
	}
	public ObservableCollection<string> MyCol { get; set; }
