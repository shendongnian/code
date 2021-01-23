    public async Task FooAsync()
    {
        while (Timer_General.IsRunning)
        {
		await Task.WhenAll(
                    Task.Run(CPU1_DoWork), Task.Run(CPU2_Work));
        }
    }
