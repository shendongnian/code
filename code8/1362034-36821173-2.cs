    string[] drives = Directory.GetLogicalDrives();
    string pathToExecutable = String.Empty;
    foreach (string drive in drives)
    {
        pathToExecutable =
            Directory
            .EnumerateFiles(drive, "xonotic.exe", SearchOption.AllDirectories)
            .FirstOrDefault();
        if (!String.IsNullOrEmpty(pathToExecutable))
        {
            break;
        }
    }
    if (String.IsNullOrEmpty(pathToExecutable))
    {
        // We did not find the executable.
    }
    else
    {
        // We found the executable. Now we can start it.
    }
