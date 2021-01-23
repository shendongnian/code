    public static class TaskExtenstions
	{
		public static SilentTask<T> IgnoreCancelAndFailure<T>(this Task<T> task)
		{
			return new SilentTask<T>(task);
		}
	}
	public class SilentTask<T>
	{
		private readonly Task<T> _inner;
		public SilentTask(Task<T> inner)
		{
			_inner = inner;
		}
		public SilentAwaiter GetAwaiter()
		{
			return new SilentAwaiter(_inner);
		}
		public class SilentAwaiter : INotifyCompletion
		{
			private readonly TaskAwaiter<T> _inner;
			private readonly Task<T> _task;
			public SilentAwaiter(Task<T> task)
			{
				_task = task;
				_inner = task.GetAwaiter();
			}
			public bool IsCompleted
			{
				get
				{
					return _task.Status == TaskStatus.RanToCompletion;
				}
			}
			public void OnCompleted(Action continuation)
			{
				_inner.OnCompleted(() =>
				{
					if (IsCompleted)
					{
						continuation();
					}
				});
			}
			public T GetResult()
			{
				return _inner.GetResult();
			}
		}
	}
