	private static Task<object> _fetcher = null;
	private static object _value = null;
	public static object Value
	{
		get
		{
			if (_value != null) return _value;
			//We're "locking" then
			var tcs = new TaskCompletionSource<object>();
			var tsk = Interlocked.CompareExchange(ref _fetcher, tcs.Task, null);
			if (tsk == null) //We won the race to set up the task
			{
				try
				{
					var result = new object(); //Whatever the real, expensive operation is
					tcs.SetResult(result);
					_value = result;
					return result;
				}
				catch (Exception ex)
				{
					Interlocked.Exchange(ref _fetcher, null); //We failed. Let someone else try again in the future
					tcs.SetException(ex);
					throw;
				}
			}
			tsk.Wait();	//Someone else is doing the work
			return tsk.Result;
		}
	}
