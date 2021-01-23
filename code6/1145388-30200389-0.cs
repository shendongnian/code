        static async Task RunIdle(CancelationToken cancelToken, TimeSpan pingInterval)
        {
            // ...
        
            // the new busy waiting ping loop
            while (!cancelToken.IsCancellationRequested)
            {
                // Do your stuff to keep the connection alive.
                // Wait a while, while freeing up the thread.
                if (!cancelToken.IsCancellationRequested)
                    await Task.Delay(pingInterval, cancelToken);
            }
        }
