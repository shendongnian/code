        public static bool SetPerMonitorDpiAwareness(ProcessDpiAwareness type = ProcessDpiAwareness.Process_Per_Monitor_DPI_Aware)
        {
            try
            {
                // for this to work make sure [assembly: DisableDpiAwareness]
                ProcessDpiAwareness awarenessType;
                GetProcessDpiAwareness(Process.GetCurrentProcess().Handle, out awarenessType);
                var result = SetProcessDpiAwareness(type);
                GetProcessDpiAwareness(Process.GetCurrentProcess().Handle, out awarenessType);
                return awarenessType == type;
            }
            catch
            {
                return false;
            }            
        }
