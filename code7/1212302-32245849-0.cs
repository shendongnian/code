    namespace EnumWnd
    {
    using System;
    using System.Runtime.InteropServices;
    using System.Text;
    [StructLayout(LayoutKind.Sequential)]
    public struct Rect
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    internal struct MonitorInfoEx
    {
        public int cbSize;
        public Rect rcMonitor;
        public Rect rcWork;
        public UInt32 dwFlags;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)] public string szDeviceName;
    }
    internal class Program
    {
        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hWnd, out Rect lpRect);
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        protected static extern int GetWindowText(IntPtr hWnd, StringBuilder strText, int maxCount);
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        protected static extern int GetWindowTextLength(IntPtr hWnd);
        [DllImport("user32.dll")]
        protected static extern bool EnumWindows(EnumWindowsProc enumProc, IntPtr lParam);
        [DllImport("user32.dll")]
        protected static extern bool IsWindowVisible(IntPtr hWnd);
        [DllImport("User32")]
        public static extern IntPtr MonitorFromWindow(IntPtr hWnd, int dwFlags);
        [DllImport("user32", EntryPoint = "GetMonitorInfo", CharSet = CharSet.Auto,
            SetLastError = true)]
        internal static extern bool GetMonitorInfoEx(IntPtr hMonitor, ref MonitorInfoEx lpmi);
        protected static bool EnumTheWindows(IntPtr hWnd, IntPtr lParam)
        {
            const int MONITOR_DEFAULTTOPRIMARY = 1;
            var mi = new MonitorInfoEx();
            mi.cbSize = Marshal.SizeOf(mi);
            GetMonitorInfoEx(MonitorFromWindow(hWnd, MONITOR_DEFAULTTOPRIMARY), ref mi);
            Rect appBounds;
            GetWindowRect(hWnd, out appBounds);
            int size = GetWindowTextLength(hWnd);
            if (size++ > 0 && IsWindowVisible(hWnd))
            {
                var sb = new StringBuilder(size);
                GetWindowText(hWnd, sb, size);
                if (sb.Length > 20)
                {
                    sb.Remove(20, sb.Length - 20);
                }
                int windowHeight = appBounds.Right - appBounds.Left;
                int windowWidth = appBounds.Bottom - appBounds.Top;
                int monitorHeight = mi.rcMonitor.Right - mi.rcMonitor.Left;
                int monitorWidth = mi.rcMonitor.Bottom - mi.rcMonitor.Top;
                bool fullScreen = (windowHeight == monitorHeight) && (windowWidth == monitorWidth);
                sb.AppendFormat(" Wnd:({0} | {1}) Mtr:({2} | {3} | Name: {4}) - {5}", windowWidth, windowHeight, monitorWidth, monitorHeight, mi.szDeviceName, fullScreen);
                Console.WriteLine(sb.ToString());
            }
            return true;
        }
        private static void Main()
        {
            while (true)
            {
                EnumWindows(EnumTheWindows, IntPtr.Zero);
                Console.ReadKey();
                Console.Clear();
            }
        }
        protected delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);
    }
