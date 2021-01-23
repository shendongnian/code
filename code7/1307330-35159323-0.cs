    // add trace config before calling validate
    configuration.TraceConfiguration = new TraceConfiguration {
    OutputFilePath="tracelog.txt", 
    DeleteOnLoad = true, 
    TraceMasks = Utils.TraceMasks.All };
    configuration.Validate(ApplicationType.Client);    
