	void Example()
	{
		// Named method
		this.NamedFuncDelegate = NamedMethod;
		string namedResult = this.NamedFuncDelegate.Invoke(5);
		Console.WriteLine (namedResult);
		// Output > Named said: 5
	
		// Anonymous Function > Lambda
		string anonyResult = this.AnonymousFuncDelegate.Invoke(106);
		Console.WriteLine (anonyResult);
		// Output > Anonymous said: 106
	}
	
	public Func<int, string> NamedFuncDelegate { get; set; }
	public Func<int, string> AnonymousFuncDelegate = (digit) => { return string.Format("Anonymous said: {0}", digit); };
	
	public string NamedMethod(int digit)
	{
		return string.Format ("Named said: {0}", digit);
	}
