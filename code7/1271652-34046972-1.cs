	private Task _loginLock = null;
	public void DoLoggedInCheck()
	{
		if (!Api.IsLoggedIn)
		{
			var tcs = new TaskCompletionSource<int>();
			var tsk = tcs.Task;
			var result = Interlocked.CompareExchange(ref _loginLock, tsk, null);
			if (result == null)
			{
				if (!Api.IsLoggedIn)
				{
					Api.Login();
				}
				Interlocked.Exchange(ref _loginLock, null);
				tcs.SetResult(1);
			}
			else
			{
				result.Wait();
			}
		}
	}
