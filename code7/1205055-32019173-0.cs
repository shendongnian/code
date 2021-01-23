    EnvDTE80.Debugger2 dbg2 = (EnvDTE80.Debugger2)dte.Debugger;
    EnvDTE80.Transport trans = dbg2.Transports.Item("Default");
    EnvDTE80.Engine dbgeng;
    dbgeng = trans.Engines.Item("Managed (v4.5, v4.0)");
    var proc2 = (EnvDTE80.Process2)dbg2.GetProcesses(trans, Environment.MachineName).Item("iisexpress.exe");
    proc2.Attach2(dbgeng);
