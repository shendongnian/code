    using System.Management;
    using System.Windows.Forms;
    public static class ScreensConfigurationDetector
    {
        public static ScreensConfiguration GetConfiguration()
        {
            ManagementObjectSearcher monitorObjectSearch = new ManagementObjectSearcher("SELECT * FROM Win32_DesktopMonitor");
            int physicalMonitors = monitorObjectSearch.Get().Count;
            int virtualMonitors = Screen.AllScreens.Length;
            
            if (physicalMonitors == 1)
            {
                return ScreensConfiguration.Single;
            }
            return physicalMonitors == virtualMonitors 
                ? ScreensConfiguration.Extended 
                : ScreensConfiguration.DuplicateOrShowOnlyOne;
        }
    }
    public enum ScreensConfiguration
    {
        Single,
        Extended,
        DuplicateOrShowOnlyOne
    }
