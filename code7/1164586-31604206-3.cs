    IConfigurationSource configSource = ConfigurationSourceFactory.Create();
    var loggingSettings = configSource.GetSection(LoggingSettings.SectionName) as LoggingSettings;    
    var data = loggingSettings.TraceListeners.First(t => t.Name == "Flat File Trace Listener") as FlatFileTraceListenerData;
    // Change the file name
    data.FileName = "trace_1.txt";
    var loggingXmlConfigSource = new SerializableConfigurationSource();
    loggingXmlConfigSource.Add(LoggingSettings.SectionName, loggingSettings);
    var logFactory = new LogWriterFactory(loggingXmlConfigSource);
    Logger.SetLogWriter(logFactory.Create());
    IConfigurationSource config = ConfigurationSourceFactory.Create();
    ExceptionPolicyFactory factory = new ExceptionPolicyFactory(config);
    ExceptionManager exManager = factory.CreateManager();
    ExceptionPolicy.SetExceptionManager(exManager);
    // This will log to the file trace_1.txt
    ExceptionPolicy.HandleException(new Exception(), "Policy");
