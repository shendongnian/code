    using System.IO;
    using System.Diagnostics;
    namespace CreateAndRunBatchFile
    {
        class Program
        {
            static void Main(string[] args)
            {
                string batTest = System.Environment.GetEnvironmentVariable("TEMP") +
                    @"\batchfile.bat";
                using (StreamWriter sw = new StreamWriter(batTest))
                {                
                    sw.WriteLine("@echo off");
                    sw.WriteLine("echo Batch program has started...");
                    sw.WriteLine("REM Add your lines of batch script code like this");
                    sw.WriteLine("pause");
                    sw.WriteLine("exit");
                }
                Process.Start(@"cmd.exe ", "/c " + batTest);
                Process.Start(@"cmd.exe ", "/c del " + batTest);
            }
        }
    }
