    public Task<int> SetOffAsync()
	{
		return Task<int>.Factory.StartNew(() =>
        { 
            /*do something else*/
            return 42;
        });
	}
