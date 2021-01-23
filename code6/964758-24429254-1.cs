    public class MyDisposableThing : IDisposable
	{
		public MyDisposableThing()
		{
			// Constructor
		}
		
		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				// Dispose managed resources
			}
			
			// Dispose unmanaged resources
		}
		
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		
		~MyDisposableThing()
		{
			Dispose(false);
		}
	}
