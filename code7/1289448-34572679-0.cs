	public class Observable<T> : IObservable<T>
	{
		protected readonly List<IObserver<T>> _subscribers = new List<IObserver<T>>();
		private class Subscription : IDisposable
		{
			List<IObserver<T>> _subscribers;
			IObserver<T> _observer;
			public Subscription(List<IObserver<T>> subscribers, IObserver<T> observer)
			{
				_subscribers = subscribers;
				_observer = observer;
			}
			public void Dispose()
			{
				_subscribers.Remove(_observer);
			}
		}
		
		public IDisposable Subscribe(IObserver<T> observer)
		{
			_subscribers.Add(observer);
			return new Subscription(_subscribers, observer);
		}
	}
