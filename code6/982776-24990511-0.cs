    using System.Management;
    using System.Management.Instrumentation;
    
    ManagementScope scope = new ManagementScope("\\\\RemoteMachine\\root\\cimv2");
    scope.Connect();
    QueryObject query = new QueryObject("SELECT * FROM Win32_Process WHERE Name ='ProcessName'");
    
    ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
    ManagementObjectCollection collection = searcher.Get();
    
    foreach(ManagementObject obj in collection)
    {
        obj.InvokeMethod("Terminate", null);
    }
