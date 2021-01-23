    public static bool FormatDrive(string driveLetter, 
    	string fileSystem = "NTFS", bool quickFormat=true, 
    	int clusterSize = 8192, string label = "", bool enableCompression = false )
    {
       if (driveLetter.Length != 2 || driveLetter[1] != ':'|| !char.IsLetter(driveLetter[0]))
          return false;
    
       //query and format given drive         
       ManagementObjectSearcher searcher = new ManagementObjectSearcher
    	(@"select * from Win32_Volume WHERE DriveLetter = '" + driveLetter + "'");
       foreach (ManagementObject vi in searcher.Get())
       {
          vi.InvokeMethod("Format", new object[] 
    	{ fileSystem, quickFormat,clusterSize, label, enableCompression });
       }
    
       return true;
    } 
