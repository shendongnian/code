    using System;
    using System.Diagnostics;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                char quote = '"';
                var startInfo = new ProcessStartInfo("cmd", "/C " + quote + "echo %time%" + quote)
                { UseShellExecute = false, RedirectStandardOutput = true };
    
                var process = new Process { EnableRaisingEvents = true };
                process.StartInfo = startInfo;
                process.Exited += (_, __) => Console.WriteLine("Exited!");
                process.Start();
                string msg1 = process.StandardOutput.ReadToEnd();
    
                Console.WriteLine(msg1);
    
                Console.ReadLine();
            }
        }
    }
