        public static class WebClientExtensions
        {
        
            public static Task DownloadFileAwaitableAsync(this WebClient instance, Uri address, 
                string fileName, CancellationToken cancellationToken)
            {
                TaskCompletionSource<object> tcs = new TaskCompletionSource<object>();
                // Subscribe for completion event
                instance.DownloadFileCompleted += instance_DownloadFileCompleted;
                // Setup cancellation
                var cancellationRegistration = cancellationToken.CanBeCanceled ? (IDisposable)cancellationToken.Register(() => { instance.CancelAsync(); }) : null;
                // Initiate asyncronous download 
                instance.DownloadFileAsync(address, fileName, Tuple.Create(tcs, cancellationRegistration));
                return tcs.Task;
            }
            static void instance_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
            {
                ((WebClient)sender).DownloadDataCompleted -= instance_DownloadFileCompleted;
                var data = (Tuple<TaskCompletionSource<object>, IDisposable>)e.UserState;
                if (data.Item2 != null) data.Item2.Dispose();
                var tcs = data.Item1;
                if (e.Cancelled)
                {
                    tcs.TrySetCanceled();
                }
                else if (e.Error != null)
                {
                    tcs.TrySetException(e.Error);
                }
                else
                {
                    tcs.TrySetResult(null);
                }
            }
        }
