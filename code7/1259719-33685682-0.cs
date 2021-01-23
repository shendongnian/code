	public class ThreadSafeSetters
	{
		private bool _foo;
		private object _locker = new object();
		public bool Foo
		{
			get
			{
				lock (_locker)
				{
					return _foo;
				}
			}
			set
			{
				lock (_locker)
				{
					_foo = value;
				}
			}
		}
	}
