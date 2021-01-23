		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Start_Via_TaskScheduler_OnClick(object sender, RoutedEventArgs e)
		{
			Time_TaskScheduler.Text = DateTime.Now.ToString("hh:mm:ss");
			// This TaskScheduler captures SynchronizationContext.Current.
			var taskScheduler = TaskScheduler.FromCurrentSynchronizationContext();
			Status_TaskScheduler.Text = "Started";
			// Start a new task (this uses the default TaskScheduler, 
			// so it will run on a ThreadPool thread).
			Task.Factory.StartNew(async () =>
			{
				// We are running on a ThreadPool thread here.
				// Do some work.
				await Task.Delay(2000);
				// Report progress to the UI.
				var reportProgressTask = ReportProgressTask(taskScheduler, () =>
				{
					Time_TaskScheduler.Text = DateTime.Now.ToString("hh:mm:ss");
					return 90;
				});
				// get result from UI thread
				var result = reportProgressTask.Result;
				Debug.WriteLine(result);
				// Do some work.
				await Task.Delay(2000); // Do some work.
				// Report progress to the UI.
				reportProgressTask = ReportProgressTask(taskScheduler, () =>
					{
						Time_TaskScheduler.Text = DateTime.Now.ToString("hh:mm:ss");
						return 10;
					});
				// get result from UI thread
				result = reportProgressTask.Result;
				Debug.WriteLine(result);
				// Do some work.
				await Task.Delay(2000); // Do some work.
				// Report progress to the UI.
				reportProgressTask = ReportProgressTask(taskScheduler, () =>
				{
					Time_TaskScheduler.Text = DateTime.Now.ToString("hh:mm:ss");
					return 340;
				});
				// get result from UI thread
				result = reportProgressTask.Result;
				Debug.WriteLine(result);
			}, 
			CancellationToken.None,
			TaskCreationOptions.None,
			TaskScheduler.Default)
				.ConfigureAwait(false)
				.GetAwaiter()
				.GetResult()
				.ContinueWith(_ =>
				{
					var reportProgressTask = ReportProgressTask(taskScheduler, () =>
					{
						Status_TaskScheduler.Text = "Finished";
						return 0;
					});
					reportProgressTask.Wait();
				});
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="taskScheduler"></param>
		/// <param name="func"></param>
		/// <returns></returns>
		private Task<int> ReportProgressTask(TaskScheduler taskScheduler, Func<int> func)
		{
			var reportProgressTask = Task.Factory.StartNew(func,
				CancellationToken.None,
				TaskCreationOptions.None,
				taskScheduler);
			return reportProgressTask;
		}
