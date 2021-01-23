    using System;
    using System.Diagnostics;
    namespace Example
    {
        class ExampleClass
        {
            static void Main()
            {
                ProcessStartInfo pi = new ProcessStartInfo("ExampleBatch.cmd", "a b c d");
                pi.CreateNoWindow = true;
                pi.UseShellExecute = false;
                pi.RedirectStandardOutput = true;
                pi.RedirectStandardInput = true;
                Process pr = Process.Start(pi);
                string output = pr.StandardOutput.ReadToEnd();
                Console.WriteLine("--------------------");
                Console.WriteLine("[" + output.ToUpper() + "]");
                Console.WriteLine("--------------------");
            }
        }
    }
