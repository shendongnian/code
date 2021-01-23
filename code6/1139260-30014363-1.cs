    private void HandleCompletion(TaskCompletionSource<object> tcs,
                                  AsyncCompletedEventArgs e,
                                  SendCompletedEventHandler handler)
    {
        if (e.UserState == tcs)
        {
            try { this.SendCompleted -= handler; }
            finally
            {
                if (e.Error != null) tcs.TrySetException(e.Error);
                else if (e.Cancelled) tcs.TrySetCanceled();
                else tcs.TrySetResult(null);
            }
        }
    }
