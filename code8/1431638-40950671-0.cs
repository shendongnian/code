	internal class TerminalHost
	{
		private InputDelegate _inputDelegate;
		public TerminalHost()
		{
			// Initialize the delegate.
			_inputDelegate = Console.Write;
		}
		internal void Start()
		{
			CancellationTokenSource tokenSource = new CancellationTokenSource();
			while (!tokenSource.IsCancellationRequested) {
				ConsoleKeyInfo keyInfo = Console.ReadKey();
				_inputDelegate(keyInfo.KeyChar);
			}
		}
		/// <summary>
		/// Adds the middleware to the invocation chain. 
		/// </summary>
		/// <param name="middleware"> The middleware to be invoked. </param>
		/// <remarks>
		/// The middleware function takes an instance of delegate that was previously invoked as an input and returns the currently invoked delegate instance as an output.
		/// </remarks>
		internal void Use(Func<InputDelegate, InputDelegate> middleware)
		{
			// Keeps a reference to the currently invoked delegate instance.
			_inputDelegate = middleware(_inputDelegate);
		}
	}
