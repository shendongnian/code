    static async Task StartAsync()
	{
		using (var queue = new SendMessageQueue(10, new SendMessageService()))
		using (var timeoutTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(4.5)))
		{
			var tasks = new List<Task>();
			for (var i = 0; i < 10; i++)
			{
				tasks.Add(queue.SendAsync(i.ToString(), timeoutTokenSource.Token));
			}
			await Task.Delay(TimeSpan.FromSeconds(4.5));
			for (var i = 10; i < 25; i++)
			{
				tasks.Add(queue.SendAsync(i.ToString(), default(CancellationToken)));
			}
			await queue.CompleteSendingAsync();
			for (var i = 0; i < tasks.Count; i++ )
			{
				try
				{
					await tasks[i];
					Console.WriteLine("Message '{0}' send.", i);
				}
				catch (TaskCanceledException)
				{
					Console.WriteLine("Message '{0}' canceled.", i);
				}
				catch (QueueOverflowException ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
		}
		Console.WriteLine("Press any key to continue...");
		Console.ReadKey();
	}
