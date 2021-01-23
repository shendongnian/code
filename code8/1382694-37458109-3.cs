	class C : B
	{
		private int third { get; set; }
		public void Test()
		{
			first = 1; // from A
			second = 2; // from B
            third = 3; // from C
		}
	}
