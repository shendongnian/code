    public static class MyExtensions
    {
        public static Task NavigateAsync(this WebBrowser wb, Uri  uri)
        {
            var tcs = new TaskCompletionSource<object>();
            LoadCompletedEventHandler completedEvent = null;
            completedEvent = (sender, e) =>
            {
                wb.LoadCompleted -= completedEvent;
                tcs.SetResult(null);
            };
            wb.LoadCompleted += completedEvent;
            wb.Navigate(uri);
            return tcs.Task;
        }
    }
