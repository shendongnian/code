    void ButtonStartSomething_Click()
    {
           
            _scheduler.Add(async() =>
            {
                  // Do something
                  await Task.Delay(10000);
                  // Do something else
            });
    }
    Scheduler _scheduler;  
    class Scheduler
	{
		public Scheduler()
		{
			_queue = new ConcurrentQueue<Func<Task>>();
			_state = STATE_IDLE;
		}
		
		
		public void Add(Func<Task> func) 
		{
		   _queue.Enqueue(func);
		   ScheduleIfNeeded();
		}
		public Task Completion
		{
			get
			{
				var t = _messageLoopTask;
				if (t != null)
				{
					return t;
				}
				else
				{
					return Task.FromResult<bool>(true);
				}
			}
		}
		
    	void ScheduleIfNeeded()
		{
			 
			if (_queue.IsEmpty) 
			{
				return;
			}
			
			if (Interlocked.CompareExchange(ref _state, STATE_RUNNING, STATE_IDLE) == STATE_IDLE)
			{
				_messageLoopTask = Task.Run(new Func<Task>(RunMessageLoop));
			}
		}
		
		async Task RunMessageLoop()
		{
			Func<Task> item;
			
			while (_queue.TryDequeue(out item))
			{
				await item();
			}
			
			var oldState = Interlocked.Exchange(ref _state, STATE_IDLE);
			System.Diagnostics.Debug.Assert(oldState == STATE_RUNNING);
			
			if (!_queue.IsEmpty)
			{
				ScheduleIfNeeded();
			}
		}
		
			
        volatile Task _messageLoopTask;	
		ConcurrentQueue<Func<Task>> _queue;
		static int _state;
		const int STATE_IDLE = 0;
		const int STATE_RUNNING = 1;
	}
