    var invalidFiles = directory.EnumerateFiles()
                                .Where(file => !allowedCLEOFiles.Contains(file.Name));
                                .ToList();
    if (invalidFiles.Any())
    {
        // ... Prompt user as before ...
        foreach (var invalidFile in invalidFiles)
        {
            File.Move(...);
        }
    }
