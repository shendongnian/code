	public static ILoggerFactory AddConsole(
		this ILoggerFactory factory,
		LogLevel minLevel,
		bool includeScopes)
	{
		factory.AddConsole((category, logLevel) => logLevel >= minLevel, includeScopes);
		return factory;
	}
