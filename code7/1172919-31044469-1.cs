    using System;
    using System.Management;
    using System.Windows.Forms;
    public static class ScreensConfigurationDetector
    {
        public static ScreensConfiguration GetConfiguration()
        {
            int physicalMonitors = GetActiveMonitors();
            int virtualMonitors = Screen.AllScreens.Length;
            
            if (physicalMonitors == 1)
            {
                return ScreensConfiguration.Single;
            }
            return physicalMonitors == virtualMonitors 
                ? ScreensConfiguration.Extended 
                : ScreensConfiguration.DuplicateOrShowOnlyOne;
        }
        private static int GetActiveMonitors()
        {
            int counter = 0;
            ManagementObjectSearcher monitorObjectSearch = new ManagementObjectSearcher("SELECT * FROM Win32_DesktopMonitor");
            foreach (ManagementObject Monitor in monitorObjectSearch.Get())
            {
                try
                {
                    if ((UInt16)Monitor["Availability"] == 3)
                    {
                        counter++;
                    }
                }
                catch (Exception)
                {
                    continue;
                }
            }
            return counter;
        }
    }
    public enum ScreensConfiguration
    {
        Single,
        Extended,
        DuplicateOrShowOnlyOne
    }
