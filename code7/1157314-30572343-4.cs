	public class TestEventArg : EventArgs
	{
		public TestEventArg(bool updatedValue)
		{
			this.UpdatedValue = updatedValue;
		}
		public bool UpdatedValue { get; private set; }
	}
	
	public class TestClass
	{
		public event EventHandler<TestEventArg> TestHappening;
	
		private bool test = false;
		public bool Test
		{
			get { return test; }
			set
			{
				var old = test;
				test = value;
				if (test != old)
					OnTestHappening(test);
			}
		}
	
		private void OnTestHappening(bool updatedValue)
		{
			var handler = TestHappening;
			if (handler != null)
				handler(this, new TestEventArg(updatedValue));
		}
	}
