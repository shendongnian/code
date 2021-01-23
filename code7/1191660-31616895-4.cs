    
    public static class WindowExtension
    {
        public static Task<bool?> ShowDialogAsync(this Window window, CancellationToken cancellationToken = new CancellationToken())
        {
            var completionSource = new TaskCompletionSource<bool?>();
            window.Dispatcher.BeginInvoke(new Action(() =>
            {
                var result = window.ShowDialog();
                // When dialog is closed, set the result to complete the returned task. If the task is already cancelled, it will be discarded.
                completionSource.TrySetResult(result);
            }));
            if (cancellationToken.CanBeCanceled)
            {
                var closeAndCancel = new Action(() => window.Dispatcher.BeginInvoke(new Action(() =>
                                                                                        {
                                                                                            completionSource.TrySetCanceled();
                                                                                            window.Close();
                                                                                        })));
                // Gets notified when cancellation is requested so that we can close window and cancel the returned task
                cancellationToken.Register(closeAndCancel);
                // Handle the case where cancellation was already requested
                if (cancellationToken.IsCancellationRequested)
                {
                    closeAndCancel();
                }
            }
            return completionSource.Task;
        }
    }
