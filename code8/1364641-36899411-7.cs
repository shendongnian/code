	public async Task<object> RunAsyncTask(Func<object> func) 
	{ 
		object result = null;
		UpdateBusyUi(true); 
		try 
		{ 
			result = await ThreadManager.StartSTATask(func); 
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
