	public async Task<TResult> RunAsyncTask<TResult>(Func<TResult> function) 
	{ 
		TResult result = default(TResult);
		UpdateBusyUi(true); 
		try 
		{ 
			result = await ThreadManager.StartSTATask(function); 
		} 
		catch (Exception ex) 
		{ 
			SendException(ex); 
			LoadSucceed = false; 
			Events.PublishOnUIThread(new BackgroundCompletedEvent { Header = BackgroundCompletedEvent.EntityActions.Error, Error = true }); 
		} 
		UpdateBusyUi(false); 
		return result;
	}
