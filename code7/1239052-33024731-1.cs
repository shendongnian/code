	public class ClassUnderTest
	{
		private IMyService _myservice;
		public ClassUnderTest(IMyService myservice)
		{
			_myservice = myservice;
		}
		public void MyMethod()
		{
			//assume I get those 3 values from somewhere, in here.
			var list = new List<string>{"abc","aaa","bbb"};
			foreach(var item in list)
				{
					try
					{
						_myservice.SendRequest(item);
					}
					catch(Exception ex)
					{
						LogError(ex);
					}
				}
		}
		
		protected virtual LogException(Exception ex)
		{
			//do logging
		}
	}
	
	public class TestableClassUnderTest : ClassUnderTest
	{
		public bool LoggingWasCalled { get; set; }
		
		protected virtual LogException(Exception ex)
		{
			LoggingWasCalled = true;
		}
	}
	
