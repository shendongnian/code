    namespace test
    {
          static class Program
            {
                /// <summary>
                /// The main entry point for the application.
                /// </summary>
                
                static void Main()
                {
                    
                    Console.WriteLine("Port number you want to clear");
                    var input = Console.ReadLine();
                    //var port = int.Parse(input);
                    var prc = new ProcManager();
                    prc.KillByPort(7972);
        
                }
            }
        
         
        
        public class PRC
         {
                public int PID { get; set; }
                public int Port { get; set; }
                public string Protocol { get; set; }
         }
            public class ProcManager
            {
                public void KillByPort(int port)
                {
                    var processes = GetAllProcesses();
                    if (processes.Any(p => p.Port == port))
                        Process.GetProcessById(processes.First(p => p.Port == port).PID)
                            .Kill();
                    else
                    {
                        Console.WriteLine("No process to kill!");
                    }
                }
        
                public List<PRC> GetAllProcesses()
                {
                    var pStartInfo = new ProcessStartInfo();
                    pStartInfo.FileName = "netstat.exe";
                    pStartInfo.Arguments = "-a -n -o";
                    pStartInfo.WindowStyle = ProcessWindowStyle.Maximized;
                    pStartInfo.UseShellExecute = false;
                    pStartInfo.RedirectStandardInput = true;
                    pStartInfo.RedirectStandardOutput = true;
                    pStartInfo.RedirectStandardError = true;
        
                    var process = new Process()
                    {
                        StartInfo = pStartInfo
                    };
                    process.Start();
        
                    var soStream = process.StandardOutput;
                    
                    var output = soStream.ReadToEnd();
                    if(process.ExitCode != 0)
                        throw new Exception("somethign broke");
        
                    var result = new List<PRC>(); 
                        
                   var lines = Regex.Split(output, "\r\n");
                    foreach (var line in lines)
                    {
                        if(line.Trim().StartsWith("Proto"))
                            continue;
                        
                        var parts = line.Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);
        
                        var len = parts.Length;
                        if(len > 2)
                            result.Add(new PRC
                            {
                                Protocol = parts[0],
                                Port = int.Parse(parts[1].Split(':').Last()),
                                PID = int.Parse(parts[len - 1])
                            });
                       
                     
                    }
                    return result;
                }
            }
    }
