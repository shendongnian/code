    public static class ActionExtentions
    {
        public static bool WaitForExit(this Action action, int timeout)
        {
            var cts = new CancellationTokenSource();
            var task = Task.Factory.StartNew(action, cts.Token);
            if (Task.WaitAny(new[] { task }, TimeSpan.FromMilliseconds(timeout)) < 0)
            {
                cts.Cancel();
                return false;
            }
            else if (task.Exception != null)
            {
                cts.Cancel();
                throw task.Exception;
            }
            return true;
        }
    }
