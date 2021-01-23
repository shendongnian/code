    public class ADBShell
    {
        private static ADBShell instance;
        //private List<Employee> employeeList = null;
        private Process shell = null;
        private StreamWriter myWriter = null;
        private static readonly object syncRoot = new object();
        private ADBShell()
        {
            if (shell == null)
            {
                shell = new Process();
                shell.StartInfo.FileName = (@"D:\ADB\ADB.exe");
                shell.StartInfo.Arguments = "shell";
                shell.StartInfo.RedirectStandardInput = true;
                shell.StartInfo.UseShellExecute = false;
                shell.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                shell.StartInfo.RedirectStandardOutput = true;
                shell.StartInfo.CreateNoWindow = true;
                shell.EnableRaisingEvents = true;
                shell.OutputDataReceived += (sender, a) => Console.WriteLine(a.Data);
                shell.Start();
                myWriter = shell.StandardInput;
                shell.BeginOutputReadLine();
            }
        }
        public static ADBShell Instance()
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new ADBShell();
                    }
                }
            }
            return instance;
        }
        public void tap(int x, int y)
        {
            myWriter.WriteLine("input tap {0} {1}", x.ToString(), y.ToString());
            Thread.Sleep(10);
        }
        public void tap(string x, string y)
        {
            myWriter.WriteLine("input tap {0} {1}", x, y);
            Thread.Sleep(10);
        }
        public void exit()
        {
            myWriter.WriteLine("exit");
        }
        public void Close()
        {
            myWriter.WriteLine("exit");
            shell.WaitForExit();
            if (!shell.HasExited)
            {
                shell.Kill();
            }
            shell.Close();
            shell.Dispose();
            myWriter.Close();
            myWriter.Dispose();
        }
     }
