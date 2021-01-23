    public void DoSomethingThatUsesB()
	{
        //_bFactory is your Func<Owned<B>>
		using(var b = _bFactory.Invoke())
        {
             ... (use b)
        }
	}
