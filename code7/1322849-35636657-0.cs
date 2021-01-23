    var testCommand = ReactiveCommand.CreateAsyncTask(async (name, ct) =>
    {
    	for (int i = 0; i < 5; i++)
    	{
    		Console.WriteLine("{0} cancellation requested: {1}", name, ct.IsCancellationRequested);
    		if (ct.IsCancellationRequested)
    		{
    			ct.ThrowIfCancellationRequested();
    		}
    		await Task.Delay(1000);
    	}
    });
    
    var whenButtonClick =
    	Observable
    	.Timer(TimeSpan.FromSeconds(2));
    
    // Execute a command that is cancelled when a button click happens.
    // Note the TakeUntil(whenButtonClick)
    testCommand
    .ExecuteAsync("first")
    .TakeUntil(whenButtonClick)
    .Subscribe(
    	onNext: _ => Console.WriteLine("first next"),
    	onCompleted: () => Console.WriteLine("first completed"));
    
    // Execute a command that runs to completion.
    testCommand
    .ExecuteAsync("second")
    .Subscribe(
    	onNext: _ => Console.WriteLine("second next"),
    	onCompleted: () => Console.WriteLine("second completed"));
