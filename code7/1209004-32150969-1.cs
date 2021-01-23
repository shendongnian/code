	public class EntityStream : IDisposable 
	{
		private IDisposable _connection = null;
	
		public EntityStream(IObservable<Entity> someLongRunningSubscriptionStream)
		{
			_stream =
				someLongRunningSubscriptionStream
				.Timestamp()
				.Scan(
					new Dictionary<string, Timestamped<Entity>>(),
					(accumulator, update) =>
					{
						accumulator[update.Value.ID] = update;
						return accumulator;
					})
				.Select(x => x.Select(y => y.Value).ToList())
				.Replay(1);
			
			_connection = _stream.Connect();
		}
		
		private IConnectableObservable<IList<Timestamped<Entity>>> _stream = null;
		
		public IObservable<IList<Timestamped<Entity>>> GetStream()
		{
			return _stream.AsObservable();
		}
		
		public void Dispose()
		{
		if (_connection != null)
		{
			_connection.Dispose();
			_connection = null;
		}
		}
	}
