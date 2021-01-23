	protected virtual void Dispose(bool disposing)
	{
		if (!disposed)
		{
			if (disposing)
			{
				// Free other state (managed objects).
			}
			
			// Free your own state (unmanaged objects).
			// Set large fields to null.
			disposed = true;
		}
	}
