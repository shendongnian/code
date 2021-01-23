      //Find process
      foreach (Process Proc in (from p in Process.GetProcesses()
                                where p.ProcessName == "taskmgr" || 
                                      p.ProcessName == "explorer"
                                select p))
      {
        // "Kill" the process
        Proc.Kill();
      }
    }
    catch (Exception ex)
    {
      ErrorLogging.WriteErrorLog(ex);
    }
    return null;
