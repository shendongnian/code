    static string getOfflineInstallId()
    {
        ManagementScope Scope;
        Scope = new ManagementScope("\\\\.\\ROOT\\cimv2");
        Scope.Connect();
        ObjectQuery Query = new ObjectQuery("SELECT OfflineInstallationId FROM SoftwareLicensingProduct");
        ManagementObjectSearcher Searcher = new ManagementObjectSearcher(Scope, Query);
    
        foreach (ManagementObject WmiObject in Searcher.Get())
        {
        	if (WmiObject["OfflineInstallationId"] != null)
    	    { 
        		return WmiObject["OfflineInstallationId"].ToString();
    	    }
        }
        return ""; //Making the compiler happy.
    }
