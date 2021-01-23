		public class HttpRequestScheduler : IHttpRequestScheduler
		{
			private IScheduler _scheduler;
			public HttpRequestScheduler(IScheduler scheduler)
			{
				_scheduler = scheduler;
			}
			public void Schedule()
			{
                // Whatever you want to do with the scheduler
                ...
			}
		}
