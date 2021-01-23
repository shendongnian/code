	public Task SuperSlowProcess(CancellationToken cancellationToken)
	{
		return Task.Run(() => {
			// you need to check cancellationToken periodically to check if cancellation has been requested
			for (int i = 0; i < 10; i++)
			{
				cancellationToken.ThrowIfCancellationRequested(); // this will throw OperationCancelledException after CancellationTokenSource.Cancel() is called
				Thread.Sleep(200); // to emulate super slow process
			}
		});
		
	}
