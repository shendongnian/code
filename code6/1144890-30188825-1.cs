    var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Service");
    ManagementObjectCollection collection = searcher.Get();
    var obj = collection.Cast<ManagementObject>()
                          .Where(o => o.Path.Path.Contains("MpsSvc"))
                          .ToList()[0];
    string displayName = obj["DisplayName"].ToString();
    ServiceController sc = new ServiceController(displayName);
