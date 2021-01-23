        var deviceType = "";
        string wmiQuery = string.Format(
            "SELECT ChassisTypes FROM Win32_SystemEnclosure");
        ManagementObjectSearcher searcher = new ManagementObjectSearcher(wmiQuery);
        ManagementObjectCollection qCollect = searcher.Get();
        foreach (ManagementObject obj in qCollect)
        {
            Int16[] rs = (Int16[])obj["ChassisTypes"];
            foreach (var item in rs)
            { 
                if (item == 9 ||
                    item == 10 ||
                    item == 14)
                {
                    deviceType = "Laptop";
                }
                else
                {
                    deviceType = "Non-Laptop";
                }
