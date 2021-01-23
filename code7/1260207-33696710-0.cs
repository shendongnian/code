    ConnectionOptions options = new ConnectionOptions();
    options.Password = args[2];
    options.Username = args[1];
    string machine= args[0];
    ManagementScope scope = new ManagementScope();
    scope.Options = options;
    scope.Path = new ManagementPath(@"\\" + machine + @"\root\cimv2");
    scope.Connect();
	
    ObjectQuery query = new ObjectQuery("Select * from Win32_Process Where Name     = '" + args[3] + "'");
    ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
    ManagementObjectCollection queryCollection = searcher.Get();
    foreach (ManagementObject m in queryCollection)
    {
    	object y = m.GetPropertyValue("ProcessID");
    	int pID = Convert.ToInt32(y);
    	m.InvokeMethod("Terminate", null);
    }
