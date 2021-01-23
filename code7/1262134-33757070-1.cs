    public static IEnumerable<string> EnumerateFilesByFilter(String path, List<String> include, List<String> exclude)
        {
            return Directory.EnumerateFiles(path).
                Where(f => include.All(i => f.Contains(i, StringComparison.OrdinalIgnoreCase))).
                Where(f => exclude.All(i => !f.Contains(i, StringComparison.OrdinalIgnoreCase)));
        }
