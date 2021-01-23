    XElement processes = new XElement("ProcessList");
    foreach(var process in Process.GetProcesses().AsEnumerable())
    {
        processes.Add(new XElement("Process", process.ProcessName));
    }
    
    var xmlProcessList = processes.ToString();
