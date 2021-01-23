    RegistryKey licenseKey = Registry.CurrentUser.OpenSubKey("Software\\Acme\\HostKeys\\test");
    
    if ( licenseKey != null )  
    {
        string strLic = (string)licenseKey.GetValue(null); // GetValue(null) will return the default of the key.
        if ( strLic != null ) 
        {
            if ( String.Compare("Installed",strLic,false) == 0 )
            {
                return new RuntimeRegistryLicense(type);
            } 
        } 
    } 
