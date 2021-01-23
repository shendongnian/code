    public void ProcessDirectory(string path)
    {
        using (var lockFile = File.Create(Path.Combine(path, "process.lock"), 256, FileOptions.DeleteOnClose))
        {
            // process the directory here
        }
    }
