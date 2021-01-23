	public async Task Handle(SomeMessage message)
	{
	    var transactionContext = AmbientTransactionContext.Current;
	    AmbientTransactionContext.Current = null;
		try
		{
			JuggleWithAppDomainsInHere();
		}
		finally
		{
			AmbientTransactionContext.Current = transactionContext;
		}
	}
