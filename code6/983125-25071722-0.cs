     List<string> servers = new List<string>();
     // Get servers from the registry (if any)
     RegistryKey key = RegistryKey.OpenBaseKey(
       Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry32);
     key = key.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server");
     object installedInstances = null;
     if (key != null) { installedInstances = key.GetValue("InstalledInstances"); }
     List<string> instances = null;
     if (installedInstances != null) { instances = ((string[])installedInstances).ToList(); }
     if (System.Environment.Is64BitOperatingSystem) {
    	/* The above registry check gets routed to the syswow portion of 
         * the registry because we're running in a 32-bit app. Need 
         * to get the 64-bit registry value(s) */
    	key = RegistryKey.OpenBaseKey(
                Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
    	key = key.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server");
    	installedInstances = null;
    	if (key != null) { installedInstances = key.GetValue("InstalledInstances"); }
    	string[] moreInstances = null;
    	if (installedInstances != null) { 
    	   moreInstances = (string[])installedInstances;
    	   if (instances == null) {
    		  instances = moreInstances.ToList();
    	   } else {
    		  instances.AddRange(moreInstances);
    	   }
    	}
     }
     foreach (string item in instances) {
        string name = System.Environment.MachineName;
    	if (item != "MSSQLSERVER") { name += @"\" + item; }
    	if (!servers.Contains(name.ToUpper())) { servers.Add(name.ToUpper()); }
     }
