    using ( var task = new Task<IConnection>( () => Factory.GetObject( typeof( IConnection ) ) ) )
    {
    	task.Start();
    
    	if( !task.Wait( timeoutMilliseconds ) )
    	{
    		throw new TimeoutException();
    	}
    
    	IConnection result = task.Result;
    }
