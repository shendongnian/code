    public class MutliThreadWorker : IDisposable
    {
        private readonly ConcurrentQueue<Action> _actions = new ConcurrentQueue<Action>();
        private readonly List<Thread> _threads = new List<Thread>();
        private bool _disposed;
        private void ThreadFunc()
        {
            while (true)
            {
                Action action;
                while (!_actions.TryDequeue(out action)) Thread.Sleep(100);
                action();
            }
        }
        public MutliThreadWorker(int numberOfThreads)
        {
			for (int i = 0; i < numberOfThreads; i++)
			{
				Thread t = new Thread(ThreadFunc);
				_threads.Add(t);
				t.Start();
			}
		}
		public void Dispose()
		{
			Dispose(true);
		}
		protected virtual void Dispose(bool disposing)
		{
			_disposed = true;
			foreach (Thread t in _threads)
				t.Abort();
			if (disposing)
				GC.SuppressFinalize(this);
		}
		public void Enqueue(Action action)
		{
			if (_disposed)
				throw new ObjectDisposedException("MultiThreadWorker");
			_actions.Enqueue(action);
		}
	}
