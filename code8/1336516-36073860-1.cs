	public class MyEventBus
	{
		private Subject<IEvent> _subject = new Subject<IEvent>();
	
		public void Post<T>(T message) where T : IEvent
		{
			_subject.OnNext(message);
		}
	
		public IObservable<T> AsObservable<T>() where T : IEvent
		{
			return _subject.OfType<T>();
		}
	}
