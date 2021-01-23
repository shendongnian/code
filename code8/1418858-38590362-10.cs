	public class Foo
	{
		private readonly Lazy<int> _bar = new Lazy<int>(() => Environment.TickCount, true);
		public int Bar
		{
			get { return this._bar.Value; }
		}
	}
