	// Shorthand
	public string MyProperty1 { get; set; }
	public string MyProperty2 { get; private set; }
	public string MyProperty3 { get; }
	// With backing field
	private string _myProperty4;
	private string _myProperty5;
	private readonly string _myProperty6;
	public string MyProperty4
	{
		get { return _myProperty4; }
		set { _myProperty4 = value; }
	}
	public string MyProperty5
	{
		get { return _myProperty5; }
		private set { _myProperty5 = value; }
	}
	public string MyProperty6
	{
		get { return _myProperty6; }
	}
