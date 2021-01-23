	string[] programArgs;
	static void Main(string[] args)
	{
		programArgs = args
	}
	
	[TestInitialize]
	public void Setup()
	{
		using (StreamReader r = new StreamReader(programArgs[1]))
		{
		_json = r.ReadToEnd();
		}
		...
	}
