    // Note: Adapted from Hans Passant's answer linked above.
    private static string GetParentProcessName() 
    {
        var myId = Process.GetCurrentProcess().Id;
        var query = string.Format("SELECT ParentProcessId FROM Win32_Process WHERE ProcessId = {0}", myId);
        var search = new ManagementObjectSearcher("root\\CIMV2", query);
        var queryObj = search.Get().OfType<ManagementBaseObject>().FirstOrDefault();
        if (queryObj == null)
        {
            return null;
        }
        var parentId = (uint)queryObj["ParentProcessId"];
        var parent = Process.GetProcessById((int)parentId);
        return parent.ProcessName;
    }
    static void Main() 
    {
        /*
           Program code here.
        */
        if (string.Equals(GetParentProcessName(), "explorer", StringComparison.InvariantCultureIgnoreCase)) 
        {
            Console.ReadLine();
        }
    }
