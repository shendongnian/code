	public class WorkerQueue<T>
	{
		public WorkerQueue(Action<T> workerMethod)
		{
			_workerMethod = workerMethod;
			Task.Factory.StartNew(WorkerAction);
		}
		private Action<T> _workerMethod;
		private void WorkerAction()
		{
			lock (_processSyncObj)
			{
				if (_workerMethod == null)
					return;
				while (true)
				{
					T item;
					if (_queue.TryTake(out item))
					{
						var method = _workerMethod;
						if (method != null)
							method(item);
					}
				}
			}
		}
		private BlockingCollection<T> _queue = new BlockingCollection<T>();
		private object _processSyncObj = new object();
		private volatile bool _isProcessing;
		public void EnqueueItem(T item)
		{
			// thought you might want to swap BlockingCollection with a normal collection since you apparently only want your read threadlocked? You're already making that sure in "WorkerAction"
			_queue.Add(item);
		}
	}
	/// <summary>
	/// Usage example
	/// </summary>
	public class Program
	{
		public void Start()
		{
			var test = new WorkerQueue<string>(WorkerMethod);
		}
		private void WorkerMethod(string s)
		{
			Console.WriteLine(s);
		}
	}
