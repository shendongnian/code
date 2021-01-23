	public static void Main()
	{
		var data1 = new Data() { Name = "Albert", Age = 99 };
		var data2 = new Data() { Name = "Zebra", Age = 1};
		var data3 = new Data() { Name = "Zebra", Age = 99};
		var data4 = new Data() { Name = "Albert", Age = 1 };
		
		_testData.Add(data1);
		_testData.Add(data2);
		_testData.Add(data3);
		_testData.Add(data4);
		
		SortList(new string[] { "Name", "Age" });
		
		foreach(var data in _testData)
		{
			Console.WriteLine(data.ToString());
		}
		Console.WriteLine(string.Empty);
		SortList(new string[] { "Age", "Name" });
		
		foreach(var data in _testData)
		{
			Console.WriteLine(data.ToString());
		}
	}
