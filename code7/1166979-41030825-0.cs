    PdCommon.Application pd = new PdCommon.Application();
    var pdm = (PdPDM.Model)pdApplication.OpenModel(fileName);
    var wsp = (PdWSP.Workspace)pdApplication.ActiveWorkspace;
    
    pdm.Close(false);
    wsp.Close(true);
    pd = null;
    
    // close powerdesigner processes
    foreach(var process in Process.GetProcesses().Where(pr => pr.ProcessName == "PdShell16"))
    {
    	process.Kill();
    }
