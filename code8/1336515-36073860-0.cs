	public interface IEvent { }
	
	public class BarcodeReaderEvent : EventArgs, IEvent { }
	
	public class MouseEvent : EventArgs, IEvent { }
	
	public class MyEventBus
	{
		private Subject<IEvent> _subject = new Subject<IEvent>();
		private IObservable<IEvent> _eventBus;
	
		public MyEventBus()
		{
			_eventBus = _subject.AsObservable();
		}
	
		public void Post(IEvent theEvent)
		{
			_subject.OnNext(theEvent);
		}
	
		public IDisposable Subscribe(IObserver<IEvent> observer)
		{
			return _eventBus.Subscribe(observer);
	     }
	}
