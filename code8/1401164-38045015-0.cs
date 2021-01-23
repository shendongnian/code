No, you can't since keywoard is reserved. But, yes, you can escape keywords by @ if accepted.
	class document
	{
		public void test()
		{
			this.@new();
		}
		public void @new()
		{
			Console.WriteLine();
		}
	}
