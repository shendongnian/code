	private string name;
	public string Name 
	{
		get { return name; }
		set 
		{
			if (string.IsNullOrEmpty(name))
				throw new ArgumentException("name cannot be null");
			name = value
		}
	}
	
