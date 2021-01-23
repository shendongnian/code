	public ICommand DoCommand
	{
		get
		{
			if(_DoCommand == null)
			{
				_DoCommand = new AsyncRelayCommand(param => this.DoIt());
			}
			return _DoCommand;
		}
	}
	public async void DoIt() {
		WordFileLocation = "Someplace a dialogue selected";
		await ParseDocument();
		Text = "Parsed Word Document";
		await ObtainDocument();
		Text = "Obtained Word Document.";  
	}
