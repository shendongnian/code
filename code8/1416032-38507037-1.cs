    // for example a field or property in your class
    private HashSet<string> ExtensionBlacklist { get; } =
        new HashSet<string>(StringComparer.InvariantCultureIgnoreCase)
        {
            ".html",
            ".htm"
        };
    // ...
    var filteredFiles = Directory.EnumerateFiles(path, "*.*")
        .Where(fn => !ExtensionBlacklist.Contains(System.IO.Path.GetExtension(fn)))
        .ToList();
 
