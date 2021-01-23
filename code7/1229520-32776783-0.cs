	private class Program
	{
		public static List<Action> actions;
		static Program()
		{
			Program.actions = new List<Action>();
		}
		private static void Main(string[] args)
		{
			Program.AddActions(10);
			Program.actions[0]();
			Program.actions[1]();
			Console.ReadLine();
		}
		public static void AddActions(int count)
		{
			for (int index = 0; index < count; ++index)
			{
				Program.\u003C\u003Ec__DisplayClass2_0 cDisplayClass20 = new Program.\u003C\u003Ec__DisplayClass2_0();
				cDisplayClass20.j = index;
				Program.actions.Add(new Action((object)cDisplayClass20, __methodptr(\u003CAddActions\u003Eb__0)));
			}
		}
		private sealed class \u003C\u003Ec__DisplayClass2_0
	    {
	      public int j;
	
			public \u003C\u003Ec__DisplayClass2_0()
			{
				base.\u002Ector();
			}
	
			internal void \u003CAddActions\u003Eb__0()
			{
				Console.Write("{0} ", (object)this.j);
			}
		}
	}
	
