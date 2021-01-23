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
    catch (Win32Exception ex)
    {
        // The associated process could not be terminated.
        // or The process is terminating.
        // or The associated process is a Win16 executable.
        ErrorLogging.WriteErrorLog(ex);
    }
    catch (NotSupportedException ex)
    {
        // You are attempting to call Kill for a process that is running on a remote computer. 
        // The method is available only for processes running on the local computer.
        ErrorLogging.WriteErrorLog(ex);
    }
    catch (InvalidOperationException ex)
    {
        // The process has already exited.
        // or There is no process associated with this Process object.
        ErrorLogging.WriteErrorLog(ex);
    }
    return null;
