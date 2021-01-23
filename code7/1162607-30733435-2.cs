	public class ProducerObservable : IObservable<Message>, IDisposable
	{
		private readonly Producer _Producer;
		private readonly Subject<Message> _Subject;
		private readonly CompositeDisposable _Disposables;
		
		public ProducerObservable()
		{
			_Subject = new Subject<Message>();
			ProducerMessageHandler fnHandler = m => _Subject.OnNext(m);
	
			_Producer = new Producer();
			_Producer.Attach(fnHandler);
			_Producer.Start();
			
			_Disposables = new CompositeDisposable();
			_Disposables.Add(_Producer);
			_Disposables.Add(_Subject);
		}
		
		public void Dispose()
		{
			_Subject.OnCompleted();
			_Disposables.Dispose();
		}
		
		public IDisposable Subscribe(IObserver<Message> objObserver)
		{
			var subscription = _Subject.Subscribe(objObserver);
			_Disposables.Add(subscription);
			return subscription;
		}
	}
