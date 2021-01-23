    foreach (DirectoryInfo __dir in _directories)
    {
        if (!__dir.EnumerateFiles().Any() && __dir.LastWriteTime < DateTime.Now.AddHours(-1))
        {
           __dir.Attributes = dir.Attributes & ~FileAttributes.ReadOnly;
           __dir.Delete();
        }
    }
