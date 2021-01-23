    public class MyTestCaseSourceAttribute : TestCaseSourceAttribute
	{
		public MyTestCaseSourceAttribute(Type sourceType, string sourceName, 
            [CallerMemberName] string name = null)
			: base(sourceType, sourceName)
		{
			SpreadSheetTestCaseSource.TestName = name;
		}
        //Another two members impl.
	}
