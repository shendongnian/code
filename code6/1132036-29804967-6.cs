	public void Example()
	{
		this.CommandsDictionary = new Dictionary<string, Func<int, string>>();
		this.CommandsDictionary.Add("Command1", (i) => { return string.Format("Let's get funky {0}",i); });
        
		string result = this.CommandsDictionary["Command1"].Invoke(1);
		Console.WriteLine (result);
	}
	
	public Dictionary<string, Func<int, string>> CommandsDictionary { get; set; }
