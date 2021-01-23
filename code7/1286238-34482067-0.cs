	public async Task FooAsync()
	{
	    while (Timer_General.IsRunning)
	    {
			await Task.Run(CPU1_DoWork);
	    }
	}
	
