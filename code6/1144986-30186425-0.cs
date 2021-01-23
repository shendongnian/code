    public class NativeMethods
    {
        [DllImport("user32.dll")]
        public static extern bool EnumDisplaySettings(string deviceName, int modeNum, ref DEVMODE devMode);
        [DllImport("user32.dll")]
        public static extern bool EnumDisplayDevices(string deviceName, int modeNum, ref DISPLAY_DEVICE displayDevice, int flags);
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct DISPLAY_DEVICE
    {
        public int cb;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string DeviceName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string DeviceString;
        public int StateFlags;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string DeviceID;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string DeviceKey;
    }
    static class Display
    {
        public static List<DISPLAY_DEVICE> GetGraphicsAdapters()
        {
            int i = 0;
            DISPLAY_DEVICE displayDevice = new DISPLAY_DEVICE();
            List<DISPLAY_DEVICE> result = new List<DISPLAY_DEVICE>();
            displayDevice.cb = Marshal.SizeOf(displayDevice);
            while (NativeMethods.EnumDisplayDevices(null, i, ref displayDevice, 1))
            {
                result.Add(displayDevice);
                i++;
            }
            return result;
        }
        public static List<DISPLAY_DEVICE> GetMonitors(string graphicsAdapter)
        {
            DISPLAY_DEVICE displayDevice = new DISPLAY_DEVICE();
            List<DISPLAY_DEVICE> result = new List<DISPLAY_DEVICE>();
            int i = 0;
            displayDevice.cb = Marshal.SizeOf(displayDevice);
            while (NativeMethods.EnumDisplayDevices(graphicsAdapter, i, ref displayDevice, 0))
            {
                result.Add(displayDevice);
                i++;
            }
            return result;
        }
        public static List<DEVMODE> GetDeviceModes(string graphicsAdapter)
        {
            int i = 0;
            DEVMODE devMode = new DEVMODE();
            List<DEVMODE> result = new List<DEVMODE>();
            while (NativeMethods.EnumDisplaySettings(graphicsAdapter, i, ref devMode))
            {
                result.Add(devMode);
                i++;
            }
            return result;
        }
    }
