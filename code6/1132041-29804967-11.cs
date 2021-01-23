	Dictionary<string, Action> commandsDictionary = new Dictionary<string, Action>();
	commandsDictionary.Add("Command1", () => Console.WriteLine("Command 1 invoked"));
	commandsDictionary.Add("Command2", () => Console.WriteLine("Command 2 invoked"));
	
	commandsDictionary["Command2"].Invoke();
    // Command 2 invoked
