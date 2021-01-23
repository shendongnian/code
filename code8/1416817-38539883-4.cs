    public IDisposable Subscribe(IObserver<int> observer)
    {
    	if (_completed)
    	{
    		...
    	}
    	else
    	{
    		return _innerObservable.Subscribe(observer);
    	}
    }
