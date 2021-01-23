    private Task<T> GetContentAsync<T>(Uri requestUri, HttpCompletionOption completionOption, T defaultValue,
            Func<HttpContent, Task<T>> readAs)
        {
            TaskCompletionSource<T> tcs = new TaskCompletionSource<T>();
            GetAsync(requestUri, completionOption).ContinueWithStandard(requestTask =>
            {
                if (HandleRequestFaultsAndCancelation(requestTask, tcs))
                {
                    return;
                }
                HttpResponseMessage response = requestTask.Result;
                if (response.Content == null)
                {
                    tcs.TrySetResult(defaultValue);
                    return;
                }
                try
                {
                    readAs(response.Content).ContinueWithStandard(contentTask =>
                    {
                        if (!HttpUtilities.HandleFaultsAndCancelation(contentTask, tcs))
                        {
                            tcs.TrySetResult(contentTask.Result);
                        }
                    });
                }
                catch (Exception ex)
                {
                    tcs.TrySetException(ex);
                }
            });
            return tcs.Task;
        }
