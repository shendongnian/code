    private void LoadApplication(string path, IntPtr handle)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int timeout = 10 * 1000;     // Timeout value (10s) in case we want to cancel the task if it's taking too long.
            Process p = Process.Start(path);
            Thread.Sleep(3000);
            Process[] proc = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(path));
            for(int j = 0 ;j<proc.Length;j++)
            {
                p = proc[j];
                //p.WaitForInputIdle();
                IntPtr Handle = new IntPtr();
                Handle = p.MainWindowHandle;
                if(Handle == IntPtr.Zero)
                {
                    continue;
                }
                while (Handle == IntPtr.Zero)
                {
                    System.Threading.Thread.Sleep(10);
                    p.Refresh();
                    if (sw.ElapsedMilliseconds > timeout)
                    {
                        sw.Stop();
                        return;
                    }
                }
                SetParent(Handle, handle);      // Set the process parent window to the window we want
       
            }
            
        }
