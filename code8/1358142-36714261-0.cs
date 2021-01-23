    using System.Management;
    
    ...
    StringBuilder sb = new StringBuilder();
    string format = "{0},{1},{2},{3},{4}";
    
    // Header line
    sb.AppendFormat(format, "DisplayName", 
                            "ServiceName", 
                            "Status", 
                            "ProcessId", 
                            "PathName");
    sb.AppendLine();
    
    ManagementObjectSearcher searcher = 
               new ManagementObjectSearcher("SELECT * FROM Win32_Service");
    foreach( ManagementObject result in searcher.Get() )
    {
    	sb.AppendFormat(format, result["DisplayName"], 
                                result["Name"], 
                                result["State"], 
                                result["ProcessId"], 
                                result["PathName"]
                       );
    	sb.AppendLine();
    }
    
    File.WriteAllText(
             @"C:\temp\ManagementObjectSearcher_services.csv", 
             sb.ToString()
    );
    
