    public void ProcessAndLog(Action action, String processName)
    {
      Log.WriteLog(DateTime.Now + $" Class {processName} Process Started");
      action();
      Log.WriteLog(DateTime.Now + $" Class {processName} Process Finished");
    }
