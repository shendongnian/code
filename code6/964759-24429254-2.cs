    public class MyDerivedDisposableThing : MyDisposableThing
	{
		public MyDerivedDisposableThing()
		{
			// Constructor
		}
		
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				// Dispose managed resources
			}
			
			// Dispose unmanaged resources
			
			// Call base class
			base.Dispose(disposing);
		}
	}
