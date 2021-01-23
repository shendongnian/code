    private readonly int _delayInMiliSeconds = 3000;
    private CancellationTokenSource _token;
    private bool _isStoped;
    
    public void StartUpdate()
    {
    	if (this._isStoped)
    	{
    		throw new InvalidOperationException();
    	}
    
    	this._token = new CancellationTokenSource();
    	this.Update();
    }
    
    public void StopUpdate()
    {
    	if (this._isStoped)
    	{
    		throw new InvalidOperationException();
    	}
    
    	this._isStoped = true;
    	this._token.Cancel();
    }
    
    private void Update()
    {
    	Task.Factory.StartNew(async () =>
    	{
    		while (!this._token.IsCancellationRequested)
    		{
    			await Task.Delay(TimeSpan.FromMilliseconds(this._delayInMiliSeconds), this._token.Token);
    
    			//your repeted action has to be called here
    		}
    	}, this._token.Token);
    }
