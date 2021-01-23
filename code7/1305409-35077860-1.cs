	public static class Disposable
	{
		public static IDisposable Create(Action dispose)
		{
			if (dispose == null)
				throw new ArgumentNullException("dispose");
			return (IDisposable)new AnonymousDisposable(dispose);
		}
	
		private sealed class AnonymousDisposable : IDisposable
		{
			private volatile Action _dispose;
	
			public AnonymousDisposable(Action dispose)
			{
				_dispose = dispose;
			}
	
			public void Dispose()
			{
				Action action = Interlocked.Exchange<Action>(ref _dispose, (Action)null);
				if (action != null)
				{
					action();
				}
			}
		}
	}
