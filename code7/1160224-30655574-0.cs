    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Security.Principal;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO.Pipes;
    using System.IO;
    
    namespace AdminRedirect
    {
        class Program
        {
            private static readonly int ProcessId = Process.GetCurrentProcess().Id;
    
            static void Main(string[] args)
            {
                bool isAdmin = IsAdministrator();
                Console.WriteLine("Id = {0}, IsAdmin = {1}", ProcessId, isAdmin);
                if (!isAdmin)
                {
                    Console.WriteLine("Press any key to spawn the admin process");
                    Console.ReadKey(intercept: true);
                    string pipeName = "mypipe-" + Guid.NewGuid();
                    Process cmd = new Process()
                    {
                        StartInfo =
                        {
                            Verb = "runas",
                            Arguments = pipeName,
                            FileName = typeof(Program).Assembly.Location,
                            UseShellExecute = true
                        }
                    };
                    
                    using (var pipeStream = new NamedPipeServerStream(pipeName))
                    {
                        cmd.Start();
                        Console.WriteLine("Started {0}", cmd.Id);
                        pipeStream.WaitForConnection();
                        Console.WriteLine("Received connection from {0}", cmd.Id);
                        using (var reader = new StreamReader(pipeStream))
                        {
                            string line;
                            while((line = reader.ReadLine()) != null)
                            {
                                Console.WriteLine(line);
                            }
                        }                
                    }
    
                    Console.WriteLine("Hit any key to end");
                    Console.ReadKey(intercept: true);
                }
                else
                {
                    if (args.Length > 0)
                    {
                        string pipeName = args[0];
                        Console.WriteLine("Opening client pipe: {0}", pipeName);
                        using (var pipeStream = new NamedPipeClientStream(pipeName))
                        {
                            pipeStream.Connect();
                            using (var writer = new StreamWriter(pipeStream))
                            {
                                StartChildProcess(writer);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("We are admin and not piping, so just run");
                        StartChildProcess(Console.Out);
                        Console.WriteLine("Hit any key to end");
                        Console.ReadKey(intercept: true);
                    }
                }
            }
    
            private static bool IsAdministrator()
            {
                WindowsIdentity identity = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
    
            private static void StartChildProcess(TextWriter output)
            {
                var cmd = new Process()
                {
                    StartInfo =
                    {
                        FileName = "cmd.exe",
                        Arguments = "/c ping 8.8.8.8",
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true
                    }
                };
                cmd.Start();
                string procOutput = cmd.StandardOutput.ReadToEnd();
                output.Write("Id: {0}, Output:{1}", cmd.Id, procOutput);
            }
        }
    }
