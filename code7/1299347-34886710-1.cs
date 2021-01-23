	private string someField;
	public string SomeProperty
	{
		get { return someField; }
		set { 
			Set(nameof(SomeProperty), ref someField, value);
		}
	}
	public ICommand DoSomethingCommand 
	{
		return new DelegateCommand(DoSomething);
	}
	private void DoSomething()
	{
		// apply your ViewModel state to the _wcfObject and do something with it
	}
