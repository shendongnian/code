            Process[] processes = Process.GetProcessesByName("your_process");
            foreach (Process process in processes)
            {
                process.Kill();
                process.WaitForExit();
            }
