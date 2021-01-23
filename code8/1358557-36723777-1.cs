	public IObservable<MyMessage> DoAsynchronousCall(MyMessage message)
	{
		return Observable.Create<MyMessage>(o =>
		{
			IObservable<MyMessage> result =
				receivedMessages
					.Where(m => m.Address == message.Address)
					.Take(1);
					
			IObservable<MyMessage> timeout =
				Observable
					.Timer(TimeSpan.FromSeconds(10.0))
					.Select(x => (MyMessage)null);
					
			IDisposable subscription =
				Observable
					.Amb(result, timeout)
					.Subscribe(o);
					
			externalClass.Send(message);
			
			return subscription;
		});
	}
