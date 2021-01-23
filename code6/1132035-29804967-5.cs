	public void Example()
	{
		this.CommandsDictionary = new Dictionary<string, Action<int>>();
		this.CommandsDictionary.Add("Command1", (i) => Console.WriteLine("Command {0} executed", i));
        this.CommandsDictionary["Command1"].Invoke(1);
	}
	
	public Dictionary<string, Action<int>> CommandsDictionary { get; set; }
