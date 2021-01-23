	public class TestDataService : IDataService
	{
		public void DoSomething()
		{
			// Implementation
		}
		
		public bool AppliesTo(string provider)
		{
			return provider.Equals("testRepository");
		}
	}
	public class ProdDataService : IDataService
	{
		public void DoSomething()
		{
			// Implementation
		}
		
		public bool AppliesTo(string provider)
		{
			return provider.Equals("prodRepository");
		}
	}
