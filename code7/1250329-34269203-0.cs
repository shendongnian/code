    static void Main(string[] args)
            {
                Timer t = new Timer(callback, null, 0, 60000);
                Thread.Sleep(System.Threading.Timeout.Infinite); 
            }
    
            // This method's signature must match the TimerCallback delegate
            private static void callback(Object state)
            {
                try
                {
                    bool isAppRunning = IsProcessOpen("APPName");
                    if (!isAppRunning)
                    {
                        Process p = new Process();
                        string strAppPath;
                        strAppPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ProgramFiles) + @"\FolderName\AppName.exe";                    
                        System.Diagnostics.Process.Start(strAppPath);                    
                    }
                }
                catch
                { }
            }
    
            public static bool IsProcessOpen(string name)
            {
                //here we're going to get a list of all running processes on
                //the computer
                foreach (Process clsProcess in Process.GetProcesses())
                {
                    if (clsProcess.ProcessName.Contains(name))
                    {
                        //if the process is found to be running then we
                        //return a true
                        return true;
                    }
                }
                //otherwise we return a false
                return false;
            }
