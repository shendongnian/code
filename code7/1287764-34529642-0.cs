	public class EventsTest
	{
		private IDisposable _subscription;
	
		public EventsTest()
		{
			IoService ioService = new IoService();
	
			_subscription =
				Observable
					.FromEvent<IoEvent, IoEventArgs>(
						a => ioService.IoEvent += a, a => ioService.IoEvent -= a)
					.Subscribe(eve =>
					{
						switch (eve.PortNum)
						{
							case 0:
								LongRunningMethod(eve.Description);
								break;
							case 1:
								//invoke a long running method
								break;
							default:
								break;
						}
					});
		}
	
		private void LongRunningMethod(string data)
		{
		}
	}
