		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Start_Via_SynchronizationContext_OnClick(object sender, RoutedEventArgs e)
		{
			// update initial time and task status
			Time_SynchronizationContext.Text = DateTime.Now.ToString("hh:mm:ss");
			Status_SynchronizationContext.Text = "Started";
			// capture synchronization context
			var sc = SynchronizationContext.Current;
			// Start a new task (this uses the default TaskScheduler, 
			// so it will run on a ThreadPool thread).
			Task.Factory.StartNew(async () =>
			{
				// We are running on a ThreadPool thread here.
				// Do some work.
				await Task.Delay(2000);
				// Report progress to the UI.
				sc.Send(state =>
				{
					Time_SynchronizationContext.Text = DateTime.Now.ToString("hh:mm:ss");
				}, null);
				// Do some work.
				await Task.Delay(2000);
				// Report progress to the UI.
				sc.Send(state =>
				{
					Time_SynchronizationContext.Text = DateTime.Now.ToString("hh:mm:ss");
				}, null);
				// Do some work.
				await Task.Delay(2000);
				// Report progress to the UI.
				sc.Send(state =>
				{
					Time_SynchronizationContext.Text = DateTime.Now.ToString("hh:mm:ss");
				}, null);
			},
			CancellationToken.None,
			TaskCreationOptions.None,
			TaskScheduler.Default)
			.ConfigureAwait(false)
			.GetAwaiter()
			.GetResult()
			.ContinueWith(_ =>
			{
				sc.Post(state =>
				{
					Status_SynchronizationContext.Text = "Finished";
				}, null);
			});
		}
