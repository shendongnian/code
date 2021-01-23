    public class SpreadSheetTestCaseSource
	{
		[ThreadStatic] 
        public static string TestName = String.Empty;
		public static IEnumerable TestCases
		{
			get
			{
				SpreadSheetTestCaseProvider.GetTestCases()
                     .Where(testCase => testCase.TestName == TestName);
			}
		}
	}
