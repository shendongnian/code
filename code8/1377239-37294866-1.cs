    public static IEnumerable<FileInfo> EnumerateFiles(string path, string searchPattern = null)
    {
        searchPattern = searchPattern ?? "*";
        var queue = new Queue<string>();
        queue.Enqueue(path);
        do
        {
            path = queue.Dequeue();
            foreach (var file in SafeEnumerateFiles(path, searchPattern))
            {
                yield return new FileInfo(file);
            }
            foreach (var directory in SafeEnumerateDirectories(path))
            {
                queue.Enqueue(directory);
            }
        }
        while (queue.Any());
    }
    static IEnumerable<string> SafeEnumerateFiles(string path, string searchPattern)
    {
        try
        {
            return Directory.EnumerateFiles(path, searchPattern);
        }
        catch (DirectoryNotFoundException) { }
        catch (SecurityException) { }
        catch (UnauthorizedAccessException) { }
        return Enumerable.Empty<string>();
    }
    static IEnumerable<string> SafeEnumerateDirectories(string path)
    {
        try
        {
            return Directory.EnumerateDirectories(path);
        }
        catch (DirectoryNotFoundException) { }
        catch (SecurityException) { }
        catch (UnauthorizedAccessException) { }
        return Enumerable.Empty<string>();
    }
