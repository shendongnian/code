    using System;
    using System.Diagnostics;
    using System.IO;
    
    namespace MultiConsole
    {
        class Program
        {
            private static void Main()
            {
                var pInfo = new ProcessStartInfo
                {
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = false,
                    FileName = "cmd.exe"
                };
    
                var p = new Process {StartInfo = pInfo};
    
                bool pStarted = false;
    
                Console.Write("Command: ");
                string command = Console.ReadLine();
                StreamWriter sWriter = null;
                while (command != "exit")
                {
                    if (!pStarted && command == "start")
                    {
                        p.Start();
                        sWriter = p.StandardInput;
                        pStarted = true;
                        ConsumeConsoleOutput(p.StandardOutput);
                        Console.WriteLine("Process started.");
                    }
                    else if (pStarted)
                    {
                        if (sWriter.BaseStream.CanWrite)
                        {
                            sWriter.WriteLine(command);
                        }
                    }
    
                    Console.Write("\nCommand: ");
                    command = Console.ReadLine();
                }
    
                if (sWriter != null) sWriter.Close();
                Console.WriteLine("Process terminated.");
                Console.ReadKey();
            }
    
            private static async void ConsumeConsoleOutput(TextReader reader)
            {
                var buffer = new char[1024];
                int cch;
    
                while ((cch = await reader.ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    Console.Write(new string(buffer, 0, cch));
                }
            }
        }
    }
