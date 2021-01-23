	void Example()
	{
		// Named method
		this.NamedActionDelegate = NamedMethod;
		this.NamedActionDelegate.Invoke("Hi", 5);
		// Output > Named said: Hi 5
	
		// Anonymous Function > Lambda
		this.AnonymousActionDelegate.Invoke("Foooo", 106);
		// Output > Anonymous said: Foooo 106
	}
	
	public Action<string, int> NamedActionDelegate { get; set; }
	public Action<string, int> AnonymousActionDelegate = (text, digit) => Console.WriteLine ("Anonymous said: {0} {1}", text, digit);
	
	public void NamedMethod(string text, int digit)
	{
		Console.WriteLine ("Named said: {0} {1}", text, digit);
	}
