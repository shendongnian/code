	public static class TestClass
	{
		public delegate void TestEventHandler(object sender, EventArgs e);
	
		public static event TestEventHandler TestHappening;
	
		private static bool test = false;
		public static bool Test
		{
			get
			{
				return test;
			}
			set
			{
				test = value;
				if (test)
				{
					OnTestHappening();
				}
			}
		}
		
		private static void OnTestHappening()
		{
			var handler = TestHappening;
			if (handler != null)
				handler(null, EventArgs.Empty);
		}
	}
