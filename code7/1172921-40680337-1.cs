    public class ScreenInformation
    {
        [StructLayout(LayoutKind.Sequential)]
        private struct ScreenRect
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }
    
        [DllImport("user32")]
        private static extern bool EnumDisplayMonitors(IntPtr hdc, IntPtr lpRect, MonitorEnumProc callback, int dwData);
    
        private delegate bool MonitorEnumProc(IntPtr hDesktop, IntPtr hdc, ref ScreenRect pRect, int dwData);
    
        public static int GetMonitorCount()
        {
            int monCount = 0;
            MonitorEnumProc callback = (IntPtr hDesktop, IntPtr hdc, ref ScreenRect prect, int d) => ++monCount > 0;
    
            if (EnumDisplayMonitors(IntPtr.Zero, IntPtr.Zero, callback, 0))
                Console.WriteLine("You have {0} monitors", monCount);
            else
                Console.WriteLine("An error occured while enumerating monitors");
    
            return monCount;
        }
    }
