    var processes = new List<Process>();
    for (int i=0;i<10;i++)
    {
        var process = Process.Start("Process.exe");
        processes.Add(process);
    }
    foreach(var process in processes)
        proccess.WaitForExit();
