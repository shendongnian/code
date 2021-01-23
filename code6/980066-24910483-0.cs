    var cdRoms = allDrives.Where(x => x.DriveType == DriveType.CDRom && x.IsReady);
    if (cdRoms.Any())
    {
        foreach(var cdRom in cdRoms)
        {
            Console.WriteLine("Drive {0}", cdRom.Name);
            Console.WriteLine("  File type: {0}", cdRom.DriveType);
        
            var di = new DirectoryInfo(cdRom.RootDirectory.Name);
            var file = di.GetFiles("*.csv", SearchOption.AllDirectories).FirstOrDefault();
            if (file == null)
            {
                errorwindow.Message = LanguageResources.Resource.File_Not_Found;
                dialogService.ShowDialog(LanguageResources.Resource.Error, errorWindow);
            }
            else
            {
                foreach (var info in di.GetFiles("*.csv", SearchOption.AllDirectories))
                {
                    Debug.Print(info.FullName);
                    ImportCSV(info.FullName);
                    break;
                }
            }
        }
    }
    else
    {
        errorwindow.Message = LanguageResources.Resource.CDRom_Error;
        dialogService.ShowDialog(LanguageResources.Resource.Error, errorWindow);
    }
