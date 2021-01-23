    try
    {
        NLog.MappedDiagnosticsLogicalContext.Set("SomeVariable", Guid.NewGuid().ToString());
        //do your work
        Log.Info("Some message here.");
        //do more work
        Log.Info("Finished!");
    }
    finally
    {
        NLog.MappedDiagnosticsLogicalContext.Remove("SomeVariable");
    }
