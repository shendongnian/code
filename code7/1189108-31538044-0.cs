    ManagementClass mc = new ManagementClass("Win32_Volume");
    ManagementObjectCollection moc = mc.GetInstances();
    foreach(ManagementObject mo in moc)
    {
    	string name = (string)mo.GetPropertyValue("Name");
    	if (name == @"C:\")
    	{
    		var props = new object[2];
    		mo.InvokeMethod("DefragAnalysis", props);
    	}
    }
