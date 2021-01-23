    string directoryName = "mydir";
    string directoryPath = "/home/username/" + directoryName;
    string tempPath = Path.Combine(Path.GetTempPath(), directoryName);
    Directory.CreateDirectory(tempPath);
    try
    {
        TransferOptions options = new TransferOptions();
        options.FilePermissions = new FilePermissions { Octal = "755" };
        try
        {
            session.PutFiles(tempPath, directoryPath, false, options).Check();
        }
        catch (InvalidOperationException)
        {
            // workaround for bug in .NET assembly prior to 5.5.5/5.6.1 beta
        }
    }
    finally
    {
        Directory.Delete(tempPath);
    }
