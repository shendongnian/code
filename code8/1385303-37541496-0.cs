        public class TaskSchedulerPool
        {
            private readonly List<Lazy<TaskScheduler>> _taskSchedulers;
            public TaskSchedulerPool(int maxSize)
            {
                _taskSchedulers = Enumerable.Range(1, maxSize)
                    .Select(
                        _ => new Lazy<TaskScheduler>(() => new ConcurrentExclusiveSchedulerPair().ExclusiveScheduler))
                    .ToList();
            }
            public TaskScheduler GetTaskScheduler(object o)
            {
                var partition = Math.Abs(o.GetHashCode())%_taskSchedulers.Count;
                return _taskSchedulers[partition].Value;
            }
        }
