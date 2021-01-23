    using System;
    using System.Diagnostics;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                Process p = new Process();
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.Arguments = "/C ipconfig";
                p.Start();
    
                var output = p.StandardOutput.ReadToEnd();
                Console.Write(output);
                Console.ReadKey();
            }
        }
    }
