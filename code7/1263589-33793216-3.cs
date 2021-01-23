     public void UpdateServicesList()
        {
            // Connect our scope to the actual WMI scope
            this.Scope.Connect();
    
            List<StringBuilder> servicesList = new List<StringBuilder>();
        // Query system for Services
        ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_Service WHERE Caption LIKE 'xxx%'");
        ManagementObjectSearcher searcher = new ManagementObjectSearcher(this.Scope, query);
        ManagementObjectCollection services = searcher.Get();
        if (services.Count > 0)
        {
            foreach (ManagementObject queryObj in services)
            {
                StringBuilder s = new StringBuilder();
                s.Append(queryObj["Caption"].ToString());
                s.Append(",");
                s.Append(queryObj["State"].ToString());
                s.Append(",");
                s.Append(queryObj["ProcessId"].ToString());
                s.Append(";");
                servicesList.Add(s);
            }
        }
         m_serverCB.setList(servicesList);//add this to call method.
    }
