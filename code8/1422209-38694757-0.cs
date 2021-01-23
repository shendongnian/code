	[TestClass]
	public class ContextHelperTests
	{
		private SomeClassWithThatMethod _instance;
		
		private string _inputText = "123 , 324 , 4";
		private int[] _expectedOutput = new int[] {123, 324, 4};
		
		[TestInitialize]
		public void Initialize()
		{
			_instance = new SomeClassWithThatMethod();
		}
		
		[TestMethod]
		public void IntArray_ValidInput_3ItemsInOutput()
		{
			var response = _instance.IntArray(_inputText);
			
			Assert.That(response, Is.EqualTo(_expectedOutput));
		}
	}
