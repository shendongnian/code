    using System.Diagnostics;
    Process[] processlist = Process.GetProcesses();
    foreach (Process process in processlist)
    {
        if (!String.IsNullOrEmpty(process.MainWindowTitle))
            Console.WriteLine("Process: {0} ID: {1} Window title: {2}" duration: {3}" , process.ProcessName, process.Id, process.MainWindowTitle, process.duration);
    }
    // i'm not sure if process.duration actually exists but it would be something like that 
