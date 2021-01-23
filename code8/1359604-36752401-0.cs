    public class Retry
	{
		public static void Do(Action action, TimeSpan retryInterval, int retryCount = 3)
		{
			Do<object>(() =>
			{
				action();
				return null;
			}, 
			retryInterval, retryCount);
		}
		public static T Do<T>(Func<T> action, TimeSpan retryInterval, int retryCount = 3)
		{
			var exceptions = new List<Exception>();
			for (int retry = 0; retry < retryCount; retry++)
			{
				try
				{
					if (retry > 0)
						Thread.Sleep(retryInterval);
					return action();
				}
				catch (ConnectionException ex)
				{
					// ***Handle the reconnection in here***
					exceptions.Add(ex);
				}
			}
			throw new AggregateException(exceptions);
		}
    }
