    private enum ProcessDPIAwareness
    {
            ProcessDPIUnaware = 0,
            ProcessSystemDPIAware = 1,
            ProcessPerMonitorDPIAware = 2
    }
    
        [DllImport("shcore.dll")]
        private static extern int SetProcessDpiAwareness(ProcessDPIAwareness value);
    
    
    
        private static void SetDpiAwareness()
            {
               if (Environment.OSVersion.Version.Major >= 6)
                     {
                           SetProcessDpiAwareness(ProcessDPIAwareness.ProcessPerMonitorDPIAware);
                     }
             }
