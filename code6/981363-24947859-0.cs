    using System.Management;
    public static void EnableTheService(string serviceName)
    {
        using (var mo = new ManagementObject(string.Format("Win32_Service.Name=\"{0}\"", serviceName)))
        {
            mo.InvokeMethod("ChangeStartMode", new object[] { "Automatic" });
        }
    }
