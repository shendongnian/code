    private ConnectionState _connectionState;
	public ConnectionState ConnectionState
	{
		get { return _connectionState; }
		set
		{
			if (value != _connectionState)
			{
				_connectionState = value;
				var tmp = ConnectionStateChanged;
				if (tmp != null)
					tmp (this, new ConnectionStateEventArgs(value));
			}
		}
	}
