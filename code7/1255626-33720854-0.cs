	/// <summary>The class from the shared assembly that defines WCF endpoint, and named events</summary>
	public static class InteropShared
	{
		// Host signals it's ready and listening. Replace the zero GUID with a new one
		public static readonly EventWaitHandle eventHostReady = new EventWaitHandle( false, EventResetMode.AutoReset, @"{00000000-0000-0000-0000-000000000000}" );
		// Client asks the host to quit. Replace the zero GUID with a new one
		public static readonly EventWaitHandle eventHostShouldStop = new EventWaitHandle( false, EventResetMode.AutoReset, @"{00000000-0000-0000-0000-000000000000}" );
		const string pipeBaseAddress = @"net.pipe://localhost";
		/// <summary>Pipe name</summary>
		// Replace the zero GUID with a new one.
		public const string pipeName = @"00000000-0000-0000-0000-000000000000";
		/// <summary>Base addresses for the hosted service.</summary>
		public static Uri baseAddress { get { return new Uri( pipeBaseAddress ); } }
		/// <summary>Complete address of the named pipe endpoint.</summary>
		public static Uri endpointAddress { get { return new Uri( pipeBaseAddress + '/' + pipeName ); } }
	}
	static class Program
	{
		/// <summary>The main entry point for the application.</summary>
		[STAThread]
		static void Main()
		{
			// The class implementing iYourService interface that calls that 32-bit DLL
			YourService singletoneInstance = new YourService();
			using( ServiceHost host = new ServiceHost( singletoneInstance, InteropShared.baseAddress ) )
			{
				// iYourService = [ServiceContract]-marked interface from the shared assembly
				host.AddServiceEndpoint( typeof( iYourService ), new NetNamedPipeBinding(), InteropShared.pipeName );
				host.Open();
				InteropShared.eventHostReady.Set();
				// Wait for quit request
				InteropShared.eventHostShouldStop.WaitOne();
				host.Close();
			}
		}
	}
