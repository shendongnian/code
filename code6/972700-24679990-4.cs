    // Get all the drives.
    DriveInfo[] allDrives = DriveInfo.GetDrives();
    // Check if any cdRom exists in the drives.
    var cdRomExists = allDrives.Any(drive=>drive.DriveType==DriveType.CDRom);
    // If at least one cd rom exists. 
    if(cdRomExists)
    {
        // Get all the cd roms.
        var cdRoms = allDrives.Where(drive=>drive.DriveType==DriveType.CDRom);
        // Loop through the cd roms collection.
        foreach(var cdRom in cdRoms)
        {
            // Check if a cd is in the cdRom.
            if(cdRom.IsReady)
            {
            
            }
            else // the cdRom is empty.
            {
            }
        }
    }
    else // There isn't any cd rom.
    {
    }
