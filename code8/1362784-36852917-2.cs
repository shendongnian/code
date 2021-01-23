    using System;
    using System.Diagnostics;
    namespace ConsoleApplication4
    {
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0 && args[0] == "/elevated")
            {
                var process = new Process();
                /*process.StartInfo.WorkingDirectory = */
                process.StartInfo.UseShellExecute = true;
                process.StartInfo.CreateNoWindow = false;
                process.StartInfo.FileName = "ConsoleApplication4.exe";
                process.StartInfo.Arguments = "startedThroughElevatedCodePath";
                process.Start();
                Environment.Exit(0);
            }
            if (args.Length > 0 && args[0] == "startedThroughElevatedCodePath")
            {
                Console.WriteLine("Hello from elevated");
            }
            else
            {
                Console.WriteLine("Hello from not elevated");
            }
            Console.Read();
        }
    }
    }
