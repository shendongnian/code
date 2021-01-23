    FileInfo[] DispatchFiles = dir1.GetFiles();
    Parallel.ForEach(DispatchFiles, aFile =>
    {
        string files = input + aFile.Name;
        if (File.Exists(files))
        {
            Split(files, output);
        }
    }
