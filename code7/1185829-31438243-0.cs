    public abstract class TransferTask
    {
    	public event EventHandler<TransferStatusChangedEventArgs> StatusChanged;
    	
    	private TaskCompletionSource<object> transferTask = new ...; //changed
    	private TransferStatus status;
    	
    	public TransferStatus Status
            {
                get { return this.status; }
                protected set
                {
                    TransferStatus oldStatus = this.status;
                    this.status = value;
    
                    OnStatusChanged(new TransferStatusChangedEventArgs(oldStatus, value));
                }
            }
    	
    	public Task Start(CancellationToken token)
    	{
    		await TransferAsync(cancellationToken);
            transferTask.SetResult(null); //complete proxy task
    	}
    	
    	protected abstract Task TransferAsync(CancellationToken cancellationToken);
    	
    	protected virtual void OnStatusChanged(TransferStatusChangedEventArgs txStatusArgs)
            {
                if (this.StatusChanged != null)
                {
                    this.StatusChanged(this, txStatusArgs);
                }
            }
    
    	public TaskAwaiter GetAwaiter()
    	{
    		return this.transferTask.Task.GetAwaiter(); //changed
    	}
    }
