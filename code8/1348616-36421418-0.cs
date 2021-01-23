	// MyTestEnum.cs
	enum MyTestEnum
	{
		First,
		Second,
		Third
	}
	// Extensions.cs
	static class Extensions
	{
		public static TResult GetEntry<TEnum, TResult>(this Dictionary<TEnum, string> dictionary, TEnum key)
		{
			string value;
			if (dictionary.TryGetValue(key, out value))
			{
				return (TResult)Convert.ChangeType(value, typeof(TResult));
			}
			return default(TResult);
		}
	}
	// most likely Program.cs
	void Main()
	{
		Dictionary<MyTestEnum, string> attributes = new Dictionary<MyTestEnum, string>();
		attributes.Add(MyTestEnum.First, "1.23");
        // *** here's the actual call to the extension method ***
		var result = attributes.GetEntry<MyTestEnum, double>(MyTestEnum.First);
		Console.WriteLine(result);
	}
