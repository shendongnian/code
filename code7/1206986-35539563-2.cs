    private CancellationTokenSource cancellationTokenSource;
    
    private void RootElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 1)
            {
                try
                {
                    this.cancellationTokenSource = new CancellationTokenSource();
                    var token = this.cancellationTokenSource.Token;
                    // Run task asynchronously for ensuring that there is no another click
                    // happened in time interval when double-click can occure.
                    Task.Run(async () =>
                    {
                        // Wait system double-click time interval.
                        await Task.Delay((int)GetDoubleClickTime(), token);
                        // Here is any logic for single-click handling.
                        Trace.WriteLine("Single-click occured");
                    }, token);
                }
                catch (OperationCanceledException)
                {
                    // This exception always occure when task is cancelled.
                    // It happening by design, just ignore it.
                }
                return;
            }
            // Cancel single-click task.
            if (this.cancellationTokenSource != null)
            {
                this.cancellationTokenSource.Cancel();
            }
            // Here is any logic for double-click handling.
            Trace.WriteLine("Double-click occured");
        }
