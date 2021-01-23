    using Microsoft.Win32;
    //...............................
    
    public  void IESetupFooter()
    {
    
    	string strKey  =  "Software\\Microsoft\\Internet Explorer\\PageSetup";
    	bool bolWritable = true;
    	string strName = "footer";
    		object oValue = "Test Footer";
    	RegistryKey oKey  = Registry.CurrentUser.OpenSubKey(strKey,bolWritable);
    	Console.Write (strKey);
    	oKey.SetValue(strName,oValue);
    	oKey.Close();
    }
