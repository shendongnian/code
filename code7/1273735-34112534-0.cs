    string Dequeue()
    {
        Interlocked.Increment(ref threadCountWaiting);
        try
        {
            while (true)
            {
                string result = queue.TryDequeue();
                if (result != null)
                    return result;
                if (cancellationToken.IsCancellationRequested || threadCountWaiting == pendingThreadCount)
                {
                    return null;
                }
                Thread.Sleep(10);
            }
        }
        finally
        {
            Interlocked.Decrement(ref threadCountWaiting);
        }
    }
