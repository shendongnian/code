    public static double GetCmToPixelRatio()
    {
        var diagVector = GetActiveDisplayDiag();
        var width = System.Windows.SystemParameters.PrimaryScreenWidth;
        return width / diagVector.X;
    }
    
    public static int GetDPIX()
    {
        var dpiXProperty = typeof(SystemParameters).GetProperty("DpiX", BindingFlags.NonPublic | BindingFlags.Static);
        return (int)dpiXProperty.GetValue(null, null);
    }
    
    private static Point GetActiveDisplayDiag()
    {
        //get active display
        string wmiQuery = string.Format("Select * from Win32_DesktopMonitor");
        ManagementObjectSearcher searcher = new ManagementObjectSearcher(wmiQuery);
        ManagementObjectCollection retObjectCollection = searcher.Get();
        foreach (ManagementObject retObject in retObjectCollection)
        {
            try
            {
                //get display id
                string regPath = (string)retObject.GetPropertyValue("PNPDeviceID");
                if (regPath != null)
                {
                    var pathInfo = regPath.Split('\\');
                    var displayId = pathInfo[1];
                    RegistryKey reg = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Enum\\DISPLAY\\" + displayId);
                    var firstSubReg = reg.GetSubKeyNames()[0];
                    reg = reg.OpenSubKey(firstSubReg + "\\Device Parameters");
                    var edid = (byte[])reg.GetValue("EDID");
                    return new Point(edid[21], edid[22]);
                }
            }
            catch (Exception) { }
        }
        return new Point();
    }
