	public class Foo
	{
		private readonly Lazy<int> _bar = new Lazy<int>(() => Environment.TickCount, true);
        //            similar to your constructorBody - ^^^^^^^^^^^^^^^^^^^^^^^^^^^
		private int Bar
		{
			get { return this._bar.Value; }
		}
	
		public void DoSomethingWithBar(string title)
		{
			Console.WriteLine("cur: {0}, foo.bar: {1} <- {2}",
                              Environment.TickCount,
                              this.Bar,
                              title);
		}
	}
