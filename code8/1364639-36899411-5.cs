	public async Task<object> RunAsyncTask(System.Action action) 
	{ 
		object result = null;
		UpdateBusyUi(true); 
		try 
		{ 
			result = await ThreadManager.StartSTATask(action); 
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
