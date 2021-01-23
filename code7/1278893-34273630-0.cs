    if (!System.IO.Directory.Exists(targetFilePathCombined))
        System.IO.Directory.CreateDirectory(targetFilePathCombined);
    string[] files = Directory.GetFiles(sourceFilePathCombined);
    foreach (var file in files)
    {
        string name = Path.GetFileName(file);
        string target = Path.Combine(targetFilePathCombined, name);
        File.Copy(file, target, true);
    }
