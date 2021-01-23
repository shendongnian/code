    private IEnumerable<string> TestGetFiles(string path, params string[] exts)
    {
        var extensions  = exts
           .Select(x => x.StartsWith(".") ? x : "." + x)
           .ToArray();
        return Directory.EnumerateFiles(path ,SearchOption.AllDirectories)            
           . Where(fn => extensions.Contains(Path.GetExtension(fn), StringComparer.InvariantCultureIgnoreCase));
    }
