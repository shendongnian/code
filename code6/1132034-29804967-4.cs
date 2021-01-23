	public void Example()
	{
		this.CommandsDictionary = new Dictionary<string, Action>();
		this.CommandsDictionary.Add("Command1", () => Console.WriteLine("Command 1 executed"));
		this.CommandsDictionary.Add("Command2", () => Console.WriteLine("Command 2 executed"));
		this.CommandsDictionary.Add("Command3", () => Console.WriteLine("Command 3 executed"));
	
		this.CommandsDictionary["Command3"].Invoke();
	}
	
	public Dictionary<string, Action> CommandsDictionary { get; set; }
