	public sealed class ConnectionStateEventArgs : EventArgs
	{
		public ConnectionState ConnectionState { get; private set; }
		public ConnectionStateEventArgs(ConnectionState connectionState)
		{
			ConnectionState = connectionState;
		}
	}
	public event EventHandler<ConnectionStateEventArgs> ConnectionStateChanged;
