    public static List<string> GetMonitorNames()
    {
        ManagementObjectSearcher searcher =
                new ManagementObjectSearcher("root\\WMI",
                "SELECT * FROM WmiMonitorBasicDisplayParams");
        var info = new List<string>();
        foreach (ManagementObject queryObj in searcher.Get()) { 
            info.Add(queryObj["InstanceName"].ToString());
        }
        return info;
    }
