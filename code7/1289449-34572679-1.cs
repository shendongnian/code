	public abstract class Observer<T> : IObserver<T>, IDisposable
	{
		private IDisposable _subscription = null;
		public void Dispose()
		{
			Unsubscribe();
		}
		public void Unsubscribe()
		{
			if (_subscription != null)
			{
				_subscription?.Dispose();
				_subscription = null;
			}
		}
		public void SubscribeTo(IObservable<T> publisher)
		{
			Unsubscribe();
			_subscription = publisher.Subscribe(this);
		}
		public abstract void OnCompleted();
		public abstract void OnError(Exception error);
		public abstract void OnNext(T value);
	}
