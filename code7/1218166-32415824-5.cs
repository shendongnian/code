    //using System.Linq;
    //using System.Management;
<!---->
    var query = "SELECT * FROM Win32_OperatingSystem";
    var searcher = new ManagementObjectSearcher(query);
    var info = searcher.Get().Cast<ManagementObject>().FirstOrDefault();
    var caption = info.Properties["Caption"].Value.ToString();
    var version = info.Properties["Version"].Value.ToString();
    var spMajorVersion = info.Properties["ServicePackMajorVersion"].Value.ToString();
    var spMinorVersion = info.Properties["ServicePackMinorVersion"].Value.ToString();
