    static void FullDirList(DirectoryInfo dir, string searchPattern, string excludeFolders, int maxSz, int maxDepth)
    {
        if(maxDepth == 0)
        {
            return;
        }
        try
        {
            foreach (FileInfo file in dir.GetFiles(searchPattern))
            {
                if (excludeFolders != "")
                    if (Regex.IsMatch(file.FullName, excludeFolders, RegexOptions.IgnoreCase)) continue;
                myStream.WriteLine(file.FullName);
                MasterFileCounter += 1;
                if (maxSz > 0 && myStream.BaseStream.Length >= maxSz)
                {
                    myStream.Close();
                    myStream = new StreamWriter(nextOutPutFile());
                }
            }
        }
        catch
        {
            // make this a spearate streamwriter to accept files that failed to be read.
            Console.WriteLine("Directory {0}  \n could not be accessed!!!!", dir.FullName);
            return;  // We alredy got an error trying to access dir so dont try to access it again
        }
        MasterFolderCounter += 1;
        foreach (DirectoryInfo d in dir.GetDirectories())
        {
            //folders.Add(d);
            // if (MasterFolderCounter > maxFolders) 
            FullDirList(d, searchPattern, excludeFolders, maxSz, depth - 1);
        }
    }
