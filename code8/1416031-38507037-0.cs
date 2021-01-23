    var extensionBlacklist = new HashSet<string>(StringComparer.InvariantCultureIgnoreCase);
    extensionBlacklist.Add(".html");
    extensionBlacklist.Add(".htm");
    var filteredFiles = Directory.EnumerateFiles(path, "*.*")
        .Where(fn => !extensionBlacklist.Contains(System.IO.Path.GetExtension(fn)))
        .ToList();
