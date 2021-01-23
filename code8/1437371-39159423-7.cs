	public bool IsDisposed()
	{
		bool isDisposed = false;
		try
		{
			isDisposed = Database.Connection != null;
		}
		catch (InvalidOperationException ex)
		{
			isDisposed = true;
		}
		return isDisposed;
	}
