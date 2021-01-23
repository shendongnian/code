	public class Program
	{
		public static void Main()
		{
			new Program().Execute();
		}
		
		public void Execute()
		{
            // lock objects
			this.fixErrorLock = new object();
			this.isLoggingInLock = new object();
			var objectsToIterate = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
			objectsToIterate.AsParallel().ForAll(this.DoWork);
		}
		private object isLoggingInLock;
		private object fixErrorLock;
		private bool isLoggingIn;
		public bool IsThereAnyThreadLoggingIn()
		{
			lock (this.isLoggingInLock)
			{
                // If no thread is logging-in, the one who asked is going to log-in
				if (!this.isLoggingIn)
					this.isLoggingIn = true;
				return this.isLoggingIn;
			}
		}
		public void DoWork(int myParam)
		{
			try
			{
				if (myParam % 4 == 0)
					throw new Exception();
			}
			catch (Exception ex)
			{
				// Is the equivalent of 'is the first thread to hit here?'
				bool canLogIn = this.IsThereAnyThreadLoggingIn();
				// Every thread with error will stop here
				lock (fixErrorLock)
				{
					// But only the first one will do the login process again
					if (canLogIn)
					{
						// Inside the login method the variable responsible for the 'isFirstThread' is restored to false
						this.LogIn();
					}
				}
				this.DoWork(myParam-1);
			}
		}
		public void LogIn()
		{
			Thread.Sleep(100);
			lock (this.isLoggingInLock)
			{
				// The login is done
				this.isLoggingIn = false;
			}
		}
	}
