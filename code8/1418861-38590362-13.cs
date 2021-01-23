	public class Foo
	{
		private readonly Lazy<int> _bar = new Lazy<int>(() => Environment.TickCount, true);
		private int Bar
		{
			get { return this._bar.Value; }
		}
	
		public void DoSomethingWithBar(string title)
		{
			Console.WriteLine("cur: {0}, foo: {1} <- {2}", Environment.TickCount, this.Bar, title);
		}
	}
