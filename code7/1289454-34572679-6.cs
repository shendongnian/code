	private class Subscription : IDisposable
	{
		WeakReference<List<IObserver<T>>> _subscribers;
		WeakReference<IObserver<T>> _observer;
		public Subscription(List<IObserver<T>> subscribers, IObserver<T> observer)
		{
			_subscribers = new WeakReference<List<IObserver<T>>>(subscribers);
			_observer = new WeakReference<IObserver<T>>(observer);
		}
		public void Dispose()
		{
			if (_subscribers != null && _observer != null)
			{
				List<IObserver<T>> subscribers;
				IObserver<T> observer;
				if (_subscribers.TryGetTarget(out subscribers) && _observer.TryGetTarget(out observer))
					subscribers.Remove(observer);
				_subscribers = null;
				_observer = null;
			}
		}
	}
