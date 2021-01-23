    public static string GetCDRomName()
    {
        // Get All drives
        var drives = DriveInfo.GetDrives();
        var cdRomName = null;
        // Iterate though all drives and if you find a CdRom get it's name 
        // and store it to cdRomName. Then stop iterating.
        foreach (DriveInfo drive in allDrives) 
        {
            if(drive.DriveType == DriveType.CDRom)
            {
                cdRomName = drive.Name;
                break;
            }
        }
        
        // If any CDRom found returns it's name. Otherwise null.
        return cdRomName;
    }
