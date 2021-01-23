	abstract class Test
	{
		public static void CreateTestFile(String fileName) {...}
	}
	
	class Test<T> : Test
		where T : ITestable
	{
		 ...
	}
	
