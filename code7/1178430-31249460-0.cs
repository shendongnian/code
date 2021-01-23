	public abstract class BufferedObserver<T> : IObserver<T>, IDisposable
	{
		private object _lck = new object();
		private IDisposable _subscription = null;
		public bool Subscribed { get { return _subscription != null; } }
		private bool _completed = false;
		public bool Completed { get { return _completed; } }
		protected readonly Queue<T> _queue = new Queue<T>();
		protected bool DataAvailable { get { lock(_lck) { return _queue.Any(); } } }
		protected int AvailableCount { get { lock (_lck) { return _queue.Count; } } }
		protected BufferedObserver()
		{
		}
		protected BufferedObserver(IObservable<T> observable)
		{
			SubscribeTo(observable);
		}
		public virtual void Dispose()
		{
			if (_subscription != null)
			{
				_subscription.Dispose();
				_subscription = null;
			}
		}
		public void SubscribeTo(IObservable<T> observable)
		{
			if (_subscription != null)
				_subscription.Dispose();
			_subscription = observable.Subscribe(this);
			_completed = false;
		}
		public virtual void OnCompleted()
		{
			_completed = true;
		}
		public virtual void OnError(Exception error)
		{ }
		public virtual void OnNext(T value)
		{
			lock (_lck)
				_queue.Enqueue(value);
		}
		protected bool GetNext(ref T buffer)
		{
			lock (_lck)
			{
				if (!_queue.Any())
					return false;
				buffer = _queue.Dequeue();
				return true;
			}
		}
		protected T NextOrDefault()
		{
			T buffer = default(T);
			GetNext(ref buffer);
			return buffer;
		}
	}
	public abstract class Processor<T> : BufferedObserver<T>
	{
		private object _lck = new object();
		private Thread _thread = null;
		private object _cancel_lck = new object();
		private bool _cancel_requested = false;
		private bool CancelRequested
		{
			get { lock(_cancel_lck) return _cancel_requested; }
			set { lock(_cancel_lck) _cancel_requested = value; }
		}
		public bool Running { get { return _thread == null ? false : _thread.IsAlive; } }
		public bool Finished { get { return _thread == null ? false : !_thread.IsAlive; } }
		protected Processor(IObservable<T> observable)
			: base(observable)
		{ }
		public override void Dispose()
		{
			if (_thread != null && _thread.IsAlive)
			{
				//CancelRequested = true;
				_thread.Join(5000);
			}
			base.Dispose();
		}
		public bool Start()
		{
			if (_thread != null)
				return false;
			_thread = new Thread(threadfunc);
			_thread.Start();
			return true;
		}
		private void threadfunc()
		{
			while (!CancelRequested && (!Completed || _queue.Any()))
			{
				if (DataAvailable)
				{
					T data = NextOrDefault();
					if (data != null && !data.Equals(default(T)))
						ProcessData(data);
				}
				else
					Thread.Sleep(10);
			}
		}
		// implement this in a sub-class to process the blocks
		protected abstract void ProcessData(T data);
	}
