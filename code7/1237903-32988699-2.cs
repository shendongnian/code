    System.IO.DirectoryInfo tempDir = new DirectoryInfo(Path.GetTempPath());
    foreach (FileInfo file in tempDir.GetFiles())
    {
        try
        {
            file.Delete(); 
        }
        catch(IOException ex)
        {
            .....
        }
    }
