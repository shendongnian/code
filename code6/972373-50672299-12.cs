    /// <summary>
    /// Start a long series of asynchronous tasks using the `Dispatcher` for coordinating
    /// UI updates.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Start_Via_Dispatcher_OnClick(object sender, RoutedEventArgs e)
    {
      // update initial start time and task status
      Time_Dispatcher.Text = DateTime.Now.ToString("hh:mm:ss");
      Status_Dispatcher.Text = "Started";
      // create UI dont event object
      var uiUpdateDone = new ManualResetEvent(false);
      // Start a new task (this uses the default TaskScheduler, 
      // so it will run on a ThreadPool thread).
      Task.Factory.StartNew(async () =>
      {
        // We are running on a ThreadPool thread here.
        // Do some work.
        await Task.Delay(2000);
        // Report progress to the UI.
        Application.Current.Dispatcher.Invoke(() =>
        {
          Time_Dispatcher.Text = DateTime.Now.ToString("hh:mm:ss");
          // signal that update is complete
          uiUpdateDone.Set();
        });
        // wait for UI thread to complete and reset event object
        uiUpdateDone.WaitOne();
        uiUpdateDone.Reset();
        // Do some work.
        await Task.Delay(2000); // Do some work.
        // Report progress to the UI.
        Application.Current.Dispatcher.Invoke(() =>
        {
          Time_Dispatcher.Text = DateTime.Now.ToString("hh:mm:ss");
          // signal that update is complete
          uiUpdateDone.Set();
        });
        // wait for UI thread to complete and reset event object
        uiUpdateDone.WaitOne();
        uiUpdateDone.Reset();
        // Do some work.
        await Task.Delay(2000); // Do some work.
        // Report progress to the UI.
        Application.Current.Dispatcher.Invoke(() =>
        {
          Time_Dispatcher.Text = DateTime.Now.ToString("hh:mm:ss");
          // signal that update is complete
          uiUpdateDone.Set();
        });
        // wait for UI thread to complete and reset event object
        uiUpdateDone.WaitOne();
        uiUpdateDone.Reset();
      },
      CancellationToken.None,
      TaskCreationOptions.None,
      TaskScheduler.Default)
        .ConfigureAwait(false)
        .GetAwaiter()
        .GetResult()
        .ContinueWith(_ =>
        {
          Application.Current.Dispatcher.Invoke(() =>
          {
            Status_Dispatcher.Text = "Finished";
            // dispose of event object
            uiUpdateDone.Dispose();
          });
        });
    }
