    public FilePathResult GetFile()
    {
        //put your logic to determine the file path here
        string name = ComputeFilePath();
        //verify that the file actually exists and retur dummy content otherwise
        FileInfo info = new FileInfo(name);
        if (!info.Exists)
        {
            using (StreamWriter writer = info.CreateText())
            {
                writer.WriteLine("File Not Found");
            }
        }
        return File(name, "application/octet-stream");
    }
