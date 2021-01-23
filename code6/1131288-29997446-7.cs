    /// <summary>
    /// This is the version that is not dependent on Windows.Forms dll.
    /// </summary>
    public static class ConnectedMonitors
    {
        private static readonly bool _isSingleMonitor = GetSystemMetrics(SM_CMONITORS) == 0;
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
            public void WithMonitorHdc(Action<MonitorInfo, IntPtr> action)
            {
                var hdc = DeviceContextHandle;
                var shouldDeleteDC = IntPtr.Zero.Equals(hdc);
                try
                {
                    if (shouldDeleteDC)
                        hdc = CreateDC(null, DeviceName, null, IntPtr.Zero);
                    action(this, hdc);
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
            mi.WithMonitorHdc((m, hdc) =>
            {
                var screenBmp = new Bitmap(m.Bounds.Width, m.Bounds.Height, PixelFormat.Format32bppArgb);
                using (var destGraphics = Graphics.FromImage(screenBmp))
                {
                    var monitorDC = new HandleRef(null, hdc);
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
        private const int SM_CMONITORS = 80;
        private const int BITBLT_SRCCOPY = 0x00CC0020;
        private const int BITBLT_CAPTUREBLT = 0x40000000;
        private const int BITBLT_CAPTURE = BITBLT_SRCCOPY | BITBLT_CAPTUREBLT;
        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
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
        [DllImport(USER32, CharSet = CharSet.Auto)]
        private static extern int GetSystemMetrics(int nIndex);
        [DllImport(GDI32, EntryPoint = "CreateDC", CharSet = CharSet.Auto)]
        static extern IntPtr CreateDC(string lpszDriver, string lpszDevice, string lpszOutput, IntPtr lpInitData);
        [DllImport(GDI32, CharSet = CharSet.Auto)]
        private static extern bool DeleteDC([In] IntPtr hdc);
        [DllImport(GDI32, CharSet = CharSet.Auto)]
        public static extern int BitBlt(HandleRef hDC, int x, int y, int nWidth, int nHeight,
                                        HandleRef hSrcDC, int xSrc, int ySrc, int dwRop);
        #endregion
    }
