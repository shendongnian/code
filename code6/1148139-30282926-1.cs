	private class Test
	{
		public int y;
	}
	private static void Main()
	{
		Test test1 = new Test { y = 1 };
		Test test2 = new Test { y = 1 };
		FieldInfo[] fields = test1.GetType().GetFields();
		int test1Value = (int)fields[0].GetValue(test1);
		int test2Value = (int)fields[0].GetValue(test2);
		Console.WriteLine(test1Value); // prints Int32
		Console.WriteLine(test1Value == test2Value); // prints true
	}
