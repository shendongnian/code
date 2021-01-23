	string versionString = "Unknown OS Version";
	var osVersion = System.Environment.OSVersion;
	if (osVersion.Platform == PlatformID.Win32NT)
	{
		versionString = string.Format("Windows NT {0}.{1}", 
									  osVersion.Version.Major, 
									  osVersion.Version.Minor); 
	}
    else
    {
        // handle non-NT Windows
    }
