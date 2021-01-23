    public static readonly Microsoft.Extensions.Logging.LoggerFactory _loggerFactory =
                        new LoggerFactory(new[] {
                        new Microsoft.Extensions.Logging.Debug.DebugLoggerProvider()
        });
    
    optionsBuilder.UseLoggerFactory(_loggerFactory);
