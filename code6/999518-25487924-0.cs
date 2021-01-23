    void processData(String taskName)
    {
       GlobalDiagnosticContext.Set("Task", taskName);
       log.Info("Hello from processData.  This should be in {0}.log", taskName);
       GlobalDiagnosticContext.Remove("Task");
    }
