        Task<Result> ComputeResultAsync()
        {
            var task = new Task<Result>(() => ComputeResult());
            task.RunSynchronously(TaskScheduler.Default);
            return task;
        }
