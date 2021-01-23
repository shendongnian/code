    public static List<string> GetMonitorNames()
    {
        ManagementClass mc = new ManagementClass("Win32_DesktopMonitor");
        ManagementObjectCollection moc = mc.GetInstances();
        var info = new List<string>();
        foreach (ManagementObject mo in moc)
        {
            info.Add(mo["Name"].ToString());
            //mo.Properties["Name"].Value.ToString();
            //break;
        }
        return info;
    }
