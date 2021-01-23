    public static class TaskExtensions
    {
        public static T SyncResult<T>(this Task<T> task)
        {
            task.RunSynchronously();
            return task.Result;
        }
    }
