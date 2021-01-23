    public class MessageLoopApartment : IDisposable
    {
    	public static MessageLoopApartment Apartament
    	{
    		get
    		{
    			if (_apartament == null)
    				_apartament = new MessageLoopApartment();
    			return _apartament;
    		}
    	}
    
    	private static MessageLoopApartment _apartament;
    	private Thread _thread; // the STA thread
    
    	private TaskScheduler _taskScheduler; // the STA thread's task scheduler
    
    	public TaskScheduler TaskScheduler { get { return _taskScheduler; } }
    
    	/// <summary>MessageLoopApartment constructor</summary>
    	public MessageLoopApartment()
    	{
    		var tcs = new TaskCompletionSource<TaskScheduler>();
    
    		// start an STA thread and gets a task scheduler
    		_thread = new Thread(startArg =>
    		{
    			EventHandler idleHandler = null;
    
    			idleHandler = (s, e) =>
    			{
    				// handle Application.Idle just once
    				Application.Idle -= idleHandler;
    				// return the task scheduler
    				tcs.SetResult(TaskScheduler.FromCurrentSynchronizationContext());
    			};
    
    			// handle Application.Idle just once
    			// to make sure we're inside the message loop
    			// and SynchronizationContext has been correctly installed
    			Application.Idle += idleHandler;
    			Application.Run();
    		});
    
    		_thread.SetApartmentState(ApartmentState.STA);
    		_thread.IsBackground = true;
    		_thread.Start();
    		_taskScheduler = tcs.Task.Result;
    	}
    
    	/// <summary>shutdown the STA thread</summary>
    	public void Dispose()
    	{
    		Dispose(true);
    		GC.SuppressFinalize(this);
    	}
    
    	protected virtual void Dispose(bool disposing)
    	{
    		if (_taskScheduler != null)
    		{
    			var taskScheduler = _taskScheduler;
    			_taskScheduler = null;
    
    			// execute Application.ExitThread() on the STA thread
    			Task.Factory.StartNew(
    				() => Application.ExitThread(),
    				CancellationToken.None,
    				TaskCreationOptions.None,
    				taskScheduler).Wait();
    
    			_thread.Join();
    			_thread = null;
    		}
    	}
    
    	/// <summary>Task.Factory.StartNew wrappers</summary>
    	public void Invoke(Action action)
    	{
    		Task.Factory.StartNew(action,
    			CancellationToken.None, TaskCreationOptions.None, _taskScheduler).Wait();
    	}
    
    	public TResult Invoke<TResult>(Func<TResult> action)
    	{
    		return Task.Factory.StartNew(action,
    			CancellationToken.None, TaskCreationOptions.None, _taskScheduler).Result;
    	}
    
    	public Task Run(Action action, CancellationToken token)
    	{
    		return Task.Factory.StartNew(action, token, TaskCreationOptions.None, _taskScheduler);
    	}
    
    	public Task<TResult> Run<TResult>(Func<TResult> action, CancellationToken token)
    	{
    		return Task.Factory.StartNew(action, token, TaskCreationOptions.None, _taskScheduler);
    	}
    
    	public Task Run(Func<Task> action, CancellationToken token)
    	{
    		return Task.Factory.StartNew(action, token, TaskCreationOptions.None, _taskScheduler).Unwrap();
    	}
    
    	public Task<TResult> Run<TResult>(Func<Task<TResult>> action, CancellationToken token)
    	{
    		return Task.Factory.StartNew(action, token, TaskCreationOptions.None, _taskScheduler).Unwrap();
    	}
    }
