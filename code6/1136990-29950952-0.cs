	[TestClass]
	public class TestClass : IDisposable
	{
		private IDisposable _disposable;
		[TestInitialize]
		public void TestInitialize()
		{
			_disposable = //new disposable object...;
		}
		[TestCleanup]
		public void Dispose()
		{
			_disposable.Dispose();
		}
