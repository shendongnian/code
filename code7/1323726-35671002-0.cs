    string path = @"SOFTWARE\7-Zip";
    
    RegistryKey keys32 = RegistryKey.OpenBaseKey ( RegistryHive.LocalMachine, RegistryView.Registry32 );
    RegistryKey keys64 = RegistryKey.OpenBaseKey ( RegistryHive.LocalMachine, RegistryView.Registry64 );
    			
    RegistryKey rkPath = null;
    rkPath = keys32.OpenSubKey ( path );
    if ( rkPath == null )
    {
    	Console.WriteLine ("32 bit version is null. Let's try 64 bit version");
    	rkPath = keys64.OpenSubKey ( path );
    }
    string result = rkPath.GetValue ( "Path" ).ToString ( );
