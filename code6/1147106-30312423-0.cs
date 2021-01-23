    Console.WriteLine("Total number of ping processes is {0}",  Process.GetProcessesByName("ping").Length);
    
    ProcessStartInfo startInfo = new ProcessStartInfo("ping");
    Process process = new Process();
    
    startInfo.CreateNoWindow = true;
    startInfo.UseShellExecute = false;
    startInfo.Arguments = "-t 8.8.8.8";
    
    Console.WriteLine("Staring ping process");
    process.StartInfo = startInfo;
    process.Start();
    Thread.Sleep(5000);
    
    Console.WriteLine("Total number of ping processes is {0}", Process.GetProcessesByName("ping").Length);
    Thread.Sleep(5000);
    
    Console.WriteLine("Killing ping process");
    process.Kill();
    Thread.Sleep(5000);
    
    Console.WriteLine("Total number of ping processes is {0}", Process.GetProcessesByName("ping").Length);
