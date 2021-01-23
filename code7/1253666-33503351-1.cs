	public sealed class StartupTask : IBackgroundTask
	{
		//has to be declared here to keep the handle alive and prevent garbage collection
		private ServerWorkers.WebServer server = new ServerWorkers.WebServer();
		public async void Run(IBackgroundTaskInstance taskInstance)
		{
			//Start the server running no need for await as its an synchronous
			server.Start();
			
			//don't exit until work is compelted
			while(server.Running)
			{
				//give up processor and allow other work to occur while you are waiting
				await Task.Yield();
            }
		}
		internal class WebServer
		{
			private const uint BufferSize = 8192;
			private StreamSocketListener listener;
			public bool Running { get; private set;}= false;
			public void Start()
			{
				Lock(this){//prevent any other code interupting
					if(!Running )//prevent multiple starts
					{
						listener = new StreamSocketListener();
        		        listener.BindServiceNameAsync("8080");
						listener.ConnectionReceived += listener_ConnectionReceived;
						Running = true;
					}
				}
            }
			public void Stop()
			{
				Lock(this){//prevent any other code interupting
					listener.Close();
					listener.Dispose();
					listener = null;
					Running = false;
				}
            }
			public void listener_ConnectionReceived(StreamSocketListener sender, StreamSocketListenerConnectionReceivedEventArgs args)
			{ 
				//process data from listerner's event
			}
		}
	}
