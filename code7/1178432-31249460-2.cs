	/// <summary>Generic IObservable implementation</summary>
	/// <typeparam name="T">Type of messages being observed</typeparam>
	public class Observable<T> : IObservable<T>
	{
		/// <summary>Subscription class to manage unsubscription of observers.</summary>
		private class Subscription : IDisposable
		{
			/// <summary>Observer list that this subscription relates to</summary>
			public readonly ConcurrentBag<IObserver<T>> _observers;
			/// <summary>Observer to manage</summary>
			public readonly IObserver<T> _observer;
			/// <summary>Initialize subscription</summary>
			/// <param name="observers">List of subscribed observers to unsubscribe from</param>
			/// <param name="observer">Observer to manage</param>
			public Subscription(ConcurrentBag<IObserver<T>> observers, IObserver<T> observer)
            {
				_observers = observers;
				_observer = observer;
			}
			/// <summary>On disposal remove the subscriber from the subscription list</summary>
			public void Dispose()
			{
				IObserver<T> observer;
				if (_observers != null && _observers.Contains(_observer))
					_observers.TryTake(out observer);
			}
		}
		// list of subscribed observers
		private readonly ConcurrentBag<IObserver<T>> _observers = new ConcurrentBag<IObserver<T>>();
		/// <summary>Subscribe an observer to this observable</summary>
		/// <param name="observer">Observer instance to subscribe</param>
		/// <returns>A subscription object that unsubscribes on destruction</returns>
		/// <remarks>Always returns a subscription.  Ensure that previous subscriptions are disposed
		/// before re-subscribing.</remarks>
		public IDisposable Subscribe(IObserver<T> observer)
		{
			// only add observer if it doesn't already exist:
			if (!_observers.Contains(observer))
				_observers.Add(observer);
			// ...but always return a new subscription.
			return new Subscription(_observers, observer);
		}
		// delegate type for threaded invocation of IObserver.OnNext method
		private delegate void delNext(T value);
		/// <summary>Send <paramref name="data"/> to the OnNext methods of each subscriber</summary>
		/// <param name="data">Data object to send to subscribers</param>
		/// <remarks>Uses delegate.BeginInvoke to send out notifications asynchronously.</remarks>
		public void Notify(T data)
		{
			foreach (var observer in _observers)
			{
				delNext handler = observer.OnNext;
				handler.BeginInvoke(data, null, null);
			}
		}
		// delegate type for asynchronous invocation of IObserver.OnComplete method
		private delegate void delComplete();
		/// <summary>Notify all subscribers that the observable has completed</summary>
		/// <remarks>Uses delegate.BeginInvoke to send out notifications asynchronously.</remarks>
		public void NotifyComplete()
		{
			foreach (var observer in _observers)
			{
				delComplete handler = observer.OnCompleted;
				handler.BeginInvoke(null, null);
			}
		}
	}
