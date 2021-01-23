	public static class ObservableProducer
	{
		public static IObservable<Message> Create()
		{
			return 
				Observable.Using(() => new Producer(), p =>
					Observable.Create<Message>(o => 
					{
						ProducerMessageHandler handler = m => o.OnNext(m);
						p.Attach(handler);
						return Disposable.Create(() => o.OnCompleted());
					}));
		}
	}
