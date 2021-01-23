	class Foo : IDisposable
	{
		~Foo() => Dispose(false);
		public void Dispose() => Dispose(true);
		
		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				// Do whatever you want to perform deterministically
				GC.SuppressFinalize(this); // No need to finalize anymore
			}
			
			// Free any unmanaged resource you hold.
		}
	}
	
