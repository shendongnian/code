    [TestFixture]
	public class TestClass
	{
		[MyTestCaseSource(typeof(SpreadSheetTestCaseSource), "TestCases")]
		public void TestMethod()
		{
			//Test logic
		}
	}
