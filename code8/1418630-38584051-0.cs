    var process = Process.GetProcessesByName("Dns_management");
    
    bool pIsRunning = Process.GetProcessesByName("Dns_Management")
                    .FirstOrDefault(p => p.MainModule.FileName.StartsWith(@"F:\VS_2015_WorkSpace\Projects\DNS_Management\DNS_Management\bin\Debug")) 
                    != default(Process);
    
                if (pIsRunning == true)
                {
                    foreach (Process p in process)
                    {
                        Console.WriteLine(p.ProcessName + " Is Running");
                    }
                                }
                else
                {
                    Console.WriteLine("The process is not available");
                }
