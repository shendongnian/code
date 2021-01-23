			var task = Task.Run(() =>
			{
				// ...
				throw new Exception("Blah");
			});
			Task.WaitAny(task);
			if (task.IsFaulted)
			{
				var error = task.Exception;
				// ...
			}
			else if (task.IsCanceled)
			{
				// ...
			}
			else
			{
				// Success
			}
