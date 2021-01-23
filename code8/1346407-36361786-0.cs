    foreach (ZipArchiveEntry entry in result)
    {
        var newName = entry.FullName.Substring(root.Length);
        string path = Path.Combine(extractPath, newName);
        if (!Directory.Exists(path))
            Directory.CreateDirectory(Path.GetDirectoryName(path));
        entry.ExtractToFile(path);
    }
