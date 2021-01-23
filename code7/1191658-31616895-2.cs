    
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
                cancellationToken.Register(closeAndCancel);
                if (cancellationToken.IsCancellationRequested)
                {
                    closeAndCancel();
                }
            }
            return completionSource.Task;
        }
    }
