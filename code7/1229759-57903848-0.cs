    public static class TaskExtensions
    {
        /// <summary>Creates a continuation that executes asynchronously when the target
        /// <see cref="Task"/> completes.</summary>
        public static Task ContinueAsync(this Task task)
        {
            return task.ContinueWith(async t => await t,
                default, TaskContinuationOptions.RunContinuationsAsynchronously,
                TaskScheduler.Default).Unwrap();
        }
        /// <summary>Creates a continuation that executes asynchronously when the target
        /// <see cref="Task{TResult}"/> completes.</summary>
        public static Task<TResult> ContinueAsync<TResult>(this Task<TResult> task)
        {
            return task.ContinueWith(async t => await t,
                default, TaskContinuationOptions.RunContinuationsAsynchronously,
                TaskScheduler.Default).Unwrap();
        }
    }
