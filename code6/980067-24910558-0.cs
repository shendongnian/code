	bool anyCdrom = false;
	bool anyReady = false;
	bool fileFound = false;
	
    // Loop through the cd roms collection
    foreach(var cdRom in  DriveInfo.GetDrives().Where(drive => drive.DriveType == DriveType.CDRom))
    {
        anyCdrom = true;
		Console.WriteLine("Drive {0}", cdRom.Name);
        Console.WriteLine("  File type: {0}", cdRom.DriveType);   
        if (cdRom.IsReady) // You may want to put in into the intial where
        {
            anyReady = true;		
            foreach (string file in Directory.EnumerateFiles(cdRom.RootDirectory.Name, "*.csv", SearchOption.AllDirectories))
            {
                fileFound = true;
				Debug.Print(file);
                ImportCSV(file);
                break;      // only looking for the first one
            }
			if(fileFound)
				break;						                
        }       
    }
    
    if(!anyCdrom)
    {
        errorwindow.Message = LanguageResources.Resource.CDRom_Error;
        dialogService.ShowDialog(LanguageResources.Resource.Error, errorWindow);
    }	
	else if(!anyReady)
	{
        errorwindow.Message = LanguageResources.Resource.CDRom_Not_Ready;
        dialogService.ShowDialog(LanguageResources.Resource.Error, errorWindow);                     
	}
	else if(!fileFound)
	{
	    errorwindow.Message = LanguageResources.Resource.File_Not_Found;
        dialogService.ShowDialog(LanguageResources.Resource.Error, errorWindow);
	}
