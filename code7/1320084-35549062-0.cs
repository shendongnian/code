	public class MySerialPortService : IsCancellationRequested
	{
		public IObservable<Data> GetData()
		{
			return Observable.Create<Data>(async (o, cts) =>
			  observer => {
				while (!cts.IsCancellationRequested) {
				  observer.OnNext(GetDataFromSerialPort());
				}
			});
		}
	}
	public class MyViewModel : IDisposable
	{
		private readonly IMySerialPortService _mySerialPortService;
		private readonly ISchedulerProvider _schedulerProvider;
		private readonly SingleAssignmentDisposable _subscription = new SingleAssignmentDisposable();
		
		public MyViewModel(IMySerialPortService mySerialPortService, ISchedulerProvider schedulerProvider)
		{
			_mySerialPortService = mySerialPortService;
			_schedulerProvider = schedulerProvider;
		}
		
		public void Start()
		{
			_subscription.Disposable = _mySerialPortService.GetData()
				.SubscribeOn(_schedulerProvider.Background)	//or _schedulerProvider.ThreadPool, or CreateEventLoopScheduler or what ever you do internally.
				.ObserveOn(_schedulerProvider.Foreground)	//or _schedulerProvider.Dispatcher etc...
				.Subscribe(
					val=> Update(val),
					ex=> ...
				)
		}
		
		public void Dispose()
		{
			_subscription.Dispose();
		}
	}
