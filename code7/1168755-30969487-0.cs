    using System;
    using System.Diagnostics;
    namespace ConsoleApplication1
    {
        class Program
        {
            Process aProcess = new Process();
            public void runProcess(string aPath, string aName, string aFiletype)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Started: {0}", DateTime.Now.ToString("dd-MMM hh:mm:ss"));
                Console.WriteLine("Will try run this file {0} {1}", aPath, aName);
                Console.WriteLine("File type {0}", aFiletype);
                string stInfoFileName;
                string stInfoArgs;
                if (aFiletype == "bat")
                {
                    stInfoFileName = "cmd.exe";
                    stInfoArgs = "/c " + aPath + aName;
                }
                else
                { //vbs
                    stInfoFileName = "cscript";
                    stInfoArgs = "/B " + aPath + aName;
                }
                this.aProcess.StartInfo.FileName = stInfoFileName;
                this.aProcess.StartInfo.Arguments = stInfoArgs;
                this.aProcess.StartInfo.WorkingDirectory = aPath;
                this.aProcess.StartInfo.UseShellExecute = false;
                this.aProcess.Start();
                Console.WriteLine("<<<got to here");
                this.aProcess.WaitForExit(); //<-- Optional if you want program running until your script exit
                this.aProcess.Close();
                Console.WriteLine("Finished: {0}", DateTime.Now.ToString("dd-MMM hh:mm:ss"));
            }
            static void Main(string[] args)
            {
                new Program().runProcess("c:\\working\\", "test.bat", "bat");
                Console.WriteLine("Exiting");
            }
        }
    }
