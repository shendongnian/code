    using System.Management;
    //....
    string query = "SELECT * FROM Win32_OperatingSystem";
    ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
    foreach (ManagementObject info in searcher.Get())
    {
        //info.Properties["Caption"].Value.ToString().Trim()
        //info.Properties["Version"].Value.ToString()
        //info.Properties["ServicePackMajorVersion"].Value.ToString()
        //info.Properties["ServicePackMinorVersion"].Value.ToString()
    }
