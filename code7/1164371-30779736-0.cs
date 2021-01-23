    string searchFileNoExt = Path.GetFileNameWithoutExtension("1346670589521421983450911196954093762922.nii");
    var filesToProcess = Directory.EnumerateFiles(rootDir, ".*.", System.IO.SearchOption.AllDirectories)
        .Where(fn => Path.GetFileNameWithoutExtension(fn).Replace(".", "").Equals(searchFileNoExt, StringComparison.InvariantCultureIgnoreCase));
    foreach (string file in filesToProcess)
        Console.WriteLine(file);
