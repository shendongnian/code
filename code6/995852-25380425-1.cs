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
		Text = "Parsed Word Document";  // won't be posted till entire stack is done, does not matter if property is raised or not.
		await ObtainDocument();
		Text = "Obtained Word Document.";  
	}
