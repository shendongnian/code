    public static class ConnectedMonitors
    {
        private static Lazy<List<MonitorInfo>> _monitors = new Lazy<List<MonitorInfo>>(GetMonitors, true);
        public static event Action MonitorInfoInvalidated;
        public class MonitorInfo
        {
            public readonly IntPtr MonitorHandle;
            public readonly IntPtr DeviceContextHandle;
            public readonly string DeviceName;
            public readonly bool IsPrimary;
            public readonly Rectangle Bounds;
            public readonly Rectangle WorkArea;
            public void WithMonitorGraphics(Action<MonitorInfo, Graphics> action)
            {
                var hdc = DeviceContextHandle;
                var shouldDeleteDC = IntPtr.Zero.Equals(hdc);
                try
                {
                    if (shouldDeleteDC)
                        hdc = CreateDC(null, DeviceName, null, IntPtr.Zero);
                    using (var graphics = Graphics.FromHdc(hdc, MonitorHandle))
                        action(this, graphics);
                }
                finally
                {
                    if (shouldDeleteDC && !IntPtr.Zero.Equals(hdc))
                        DeleteDC(hdc);
                }
            }
            internal MonitorInfo(
                IntPtr hMonitor, 
                IntPtr hDeviceContext, 
                string deviceName,
                bool isPrimary,
                Rectangle bounds,
                Rectangle workArea)
            {
                this.MonitorHandle = hMonitor;
                this.DeviceContextHandle = hDeviceContext;
                this.DeviceName = deviceName;
                this.IsPrimary = isPrimary;
                this.Bounds = bounds;
                this.WorkArea = workArea;
            }
        }
        public static void CaptureScreen(MonitorInfo mi, string fileName)
        {
            mi.WithMonitorGraphics((m, g) =>
            {
                var screenBmp = new Bitmap(m.Bounds.Width, m.Bounds.Height, PixelFormat.Format32bppArgb);
                using (var destGraphics = Graphics.FromImage(screenBmp))
                {
                    var monitorDC = new HandleRef(null, g.GetHdc());
                    var destDC = new HandleRef(null, destGraphics.GetHdc());
                    var result = BitBlt(destDC, 0, 0, m.Bounds.Width, m.Bounds.Height, monitorDC, 0, 0, unchecked((int)BITBLT_SRCCOPY));
                    if (result == 0)
                        throw new Win32Exception();
                }
                screenBmp.Save(fileName);
            });
        }
        public static IEnumerable<MonitorInfo> Monitors
        {
            get { return _monitors.Value; }
        }
        private static List<MonitorInfo> GetMonitors()
        {
            // Get info on all monitors
            var cb = new EnumMonitorsCallback();
            EnumDisplayMonitors(IntPtr.Zero, IntPtr.Zero, cb.Callback, IntPtr.Zero);
            // Register for events invalidating monitor info.
            SystemEvents.DisplaySettingsChanging += OnDisplaySettingsChanging;
            SystemEvents.UserPreferenceChanged += OnUserPreferenceChanged;
            // Return result.
            return cb.Monitors;
        }
        private class EnumMonitorsCallback
        {
            public List<MonitorInfo> Monitors = new List<MonitorInfo>();
            public bool Callback(IntPtr hMonitor, IntPtr hdcMonitor, ref RECT lprcMonitor, IntPtr lparam)
            {
                // Get its info
                var info = new MONITORINFOEX();
                info.Size = Marshal.SizeOf(typeof(MONITORINFOEX));
                GetMonitorInfo(hMonitor, ref info);
                // Decode the info
                var isPrimary = (hMonitor == (IntPtr)PRIMARY_MONITOR) || ((info.Flags & MONITORINFOF_PRIMARY) != 0);
                var bounds = Rectangle.FromLTRB(info.Monitor.Left, info.Monitor.Top, info.Monitor.Right, info.Monitor.Bottom);
                var workArea = Rectangle.FromLTRB(info.WorkArea.Left, info.WorkArea.Top, info.WorkArea.Right, info.WorkArea.Bottom);
                var deviceName = info.DeviceName.TrimEnd('\0');
                // Create info for this monitor and add it.
                Monitors.Add(new MonitorInfo(hMonitor, hdcMonitor, deviceName, isPrimary, bounds, workArea));
                return true;
            }
        }
        private static void OnDisplaySettingsChanging(object sender, EventArgs e)
        {
            InvalidateInfo();
        }
        private static void OnUserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e)
        {
            InvalidateInfo();
        }
        private static void InvalidateInfo()
        {
            SystemEvents.DisplaySettingsChanging -= OnDisplaySettingsChanging;
            SystemEvents.UserPreferenceChanged -= OnUserPreferenceChanged;
            var cur = _monitors;
            _monitors = new Lazy<List<MonitorInfo>>(GetMonitors, true);
            var notifyInvalidated = MonitorInfoInvalidated;
            if (notifyInvalidated != null)
                notifyInvalidated();
        }
        #region Interop
        private const string USER32 = @"user32.dll";
        private const string GDI32 = @"gdi32.dll";
        private const int PRIMARY_MONITOR = unchecked((int)0xBAADF00D);
        private const int MONITORINFOF_PRIMARY = 0x00000001;
        private const int BITBLT_SRCCOPY = 0x00CC0020;
        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            /// <summary>
            /// The x-coordinate of the upper-left corner of the rectangle.
            /// </summary>
            public int Left;
            /// <summary>
            /// The y-coordinate of the upper-left corner of the rectangle.
            /// </summary>
            public int Top;
            /// <summary>
            /// The x-coordinate of the lower-right corner of the rectangle.
            /// </summary>
            public int Right;
            /// <summary>
            /// The y-coordinate of the lower-right corner of the rectangle.
            /// </summary>
            public int Bottom;
        }
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        private struct MONITORINFOEX
        {
            public int Size;
            public RECT Monitor;
            public RECT WorkArea;
            public uint Flags;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string DeviceName;
        }
        delegate bool EnumMonitorsDelegate(IntPtr hMonitor, IntPtr hdcMonitor, ref RECT lprcMonitor, IntPtr dwData);
        [DllImport(USER32, CharSet=CharSet.Auto)]
        private static extern bool EnumDisplayMonitors(IntPtr hdc, IntPtr lprcClip, EnumMonitorsDelegate lpfnEnum, IntPtr dwData);
        [DllImport(USER32, CharSet = CharSet.Auto)]
        private static extern bool GetMonitorInfo(IntPtr hMonitor, ref MONITORINFOEX lpmi);
        [DllImport(GDI32, CharSet = CharSet.Auto)]
        static extern IntPtr CreateDC(string lpszDriver, string lpszDevice, string lpszOutput, IntPtr lpInitData);
        [DllImport(GDI32, CharSet = CharSet.Auto)]
        private static extern bool DeleteDC([In] IntPtr hdc);
        [DllImport(GDI32, CharSet = CharSet.Auto)]
        public static extern int BitBlt(
            HandleRef hDC, int x, int y, int nWidth, int nHeight,
            HandleRef hSrcDC, int xSrc, int ySrc, int dwRop);
        #endregion
    }
