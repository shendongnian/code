	void Main()
	{
		List<object> mylist = new List<object> 
		{
			"test",
			DateTime.Now,
			new List<TimeSpan>()
			{
				TimeSpan.FromSeconds(10),
				TimeSpan.FromMinutes(10)
			}
		};
		
		Serialize(mylist);
	}
	
	public string ObjectToCSVString(object obj)
	{
		return obj.ToString();
	}
	
	public void Serialize(IEnumerable Sequence)
	{
		foreach (var item in Sequence)
		{
			if (item is IEnumerable && !(item is string)) // careful, string is IEnumerable<char>
			{
				Serialize(item as IEnumerable);
			}
			else
			{
				Console.WriteLine(ObjectToCSVString(item));
			}
		}
	}
