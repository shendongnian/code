    public static string GetMonitorNames()
    {
        ManagementClass mc = new ManagementClass("Win32_DesktopMonitor");
        ManagementObjectCollection moc = mc.GetInstances();
        var infoList = new List<string>();
        foreach (ManagementObject mo in moc)
        {
            infoList.Add(mo["Name"].ToString());
            //mo.Properties["Name"].Value.ToString();
            //break;
        }
        return string.Join(",", infoList);
    }
