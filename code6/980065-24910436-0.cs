    // Gets all the drives 
    DriveInfo[] allDrives = DriveInfo.GetDrives();
    
    // Get all the cd roms
    var cdRoms = allDrives.Where(x=>x.DriveType==DriveType.CDRom);
    
    if (cdRoms.Count() > 0)
    {
        bool found = false;
        // Loop through the cd roms collection
        foreach(var cdRom in cdRoms)
        {
            Console.WriteLine("Drive {0}", cdRom.Name);
            Console.WriteLine("  File type: {0}", cdRom.DriveType);
    
            if (cdRom.IsReady == true)
            {
                DirectoryInfo di = new DirectoryInfo(cdRom.RootDirectory.Name);
    
                var file = di.GetFiles("*.csv", SearchOption.AllDirectories).FirstOrDefault();
    
                if (file == null)
                {
                    errorwindow.Message = LanguageResources.Resource.File_Not_Found;
                    dialogService.ShowDialog(LanguageResources.Resource.Error, errorWindow);
                }
                else
                {
                    foreach (FileInfo info in di.GetFiles("*.csv", SearchOption.AllDirectories))
                    {
                        Debug.Print(info.FullName);
                        ImportCSV(info.FullName);
                        found = true;
                        break;      // only looking for the first one
                    }
                }
            }
            else
            {
                Debug.Print(string.Format("Drive {0} is not ready", cdRom.Name));
            }
        }
        if (!found)
        {
            errorwindow.Message = LanguageResources.Resource.CDRom_Not_Ready;
            dialogService.ShowDialog(LanguageResources.Resource.Error, errorWindow);              
        }
    }
    else
    {
        errorwindow.Message = LanguageResources.Resource.CDRom_Error;
        dialogService.ShowDialog(LanguageResources.Resource.Error, errorWindow);
    }
