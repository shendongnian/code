    private static string GetParentProcessName() 
    {
        var myId = Process.GetCurrentProcess().Id;
        var query = string.Format("SELECT ParentProcessId FROM Win32_Process WHERE ProcessId = {0}", myId);
        var search = new ManagementObjectSearcher("root\\CIMV2", query);
        var results = search.Get().GetEnumerator();
        results.MoveNext();
        var queryObj = results.Current;
        var parentId = (uint)queryObj["ParentProcessId"];
        var parent = Process.GetProcessById((int)parentId);
        return parent.ProcessName;
    }
    static void Main() 
    {
        /*
           Program code here.
        */
        if (GetParentProcessName() == "explorer") 
        {
            Console.ReadLine();
        }
    }
