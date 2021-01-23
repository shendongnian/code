	builder.Register<IConnection>((c, p) =>
	{
		var type = p.TypedAs<ConnectionType>();
		switch (type)
		{
			case ConnectionType.Ssh:
				return new SshConnection();
			case ConnectionType.Telnet:
				return new TelnetConnection();
			default:
				throw new ArgumentException("Invalid connection type");
		}
	})
	.As<IConnection>();
