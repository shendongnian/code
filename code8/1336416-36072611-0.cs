    [Fact]
    public void Test_LogMessages()
    {
        InitAppSink();
        var logger = new LoggerConfiguration().ReadFrom.AppSettings()
            .WriteTo.Sink(testSink)
            .MinimumLevel.ControlledBy(_levelSwitch)
            .CreateLogger();
        logger.Information("Information Test Log Entry");
        logger.Debug("Debug Test Log Entry");
        ((IDisposable)logger).Dispose();
    }
