			Task task = Task.Run(() =>
			{
				while (true) {
					token.ThrowIfCancellationRequested();
					Console.Write("*");
					Thread.Sleep(1000);
				}
			}, token).ContinueWith((t) =>
			{
				//t.Exception.Handle((e) => true); //there is no exception
				Console.WriteLine("You have canceled the task");
			}, TaskContinuationOptions.OnlyOnCanceled);
