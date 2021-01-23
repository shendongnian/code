    class Program
    {
        static void Main(string[] args)
        {
            var Processes = Process.GetProcesses();
            foreach(var proc in Processes)
            {
                if(proc.ProcessName=="MyProcessName")
                Console.WriteLine(ProcessExecutablePath(proc));
            }
            Console.ReadKey();
        }
        static private string ProcessExecutablePath(Process process)
        {
            try
            {
                return process.MainModule.FileName;
            }
            catch
            {
                string query = "SELECT ExecutablePath, ProcessID FROM Win32_Process";
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
                foreach (ManagementObject item in searcher.Get())
                {
                    object id = item["ProcessID"];
                    object path = item["ExecutablePath"];
                    if (path != null && id.ToString() == process.Id.ToString())
                    {
                        return path.ToString();
                    }
                }
            }
            return "";
        }
    }
