    public static List<int> GetNumbers(string str)
	{
		List<int> numbers = new List<int>();
		foreach (data; str.Split(' '))
		{
			int value;
			if (int.TryParse(data, out value))
				numbers.Add(value);
		}
		return numbers;
	}
