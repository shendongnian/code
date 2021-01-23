    // find and iterate all solution files
    foreach(var filePath in RecursiveGetFile(
        Context,
        "./",
        "*.sln",
        path=>!path.EndsWith("node_modules", StringComparison.OrdinalIgnoreCase)
        ))
    {
        Information("{0}", filePath);
    }
    // Utility method to recursively find files
    public static IEnumerable<FilePath> RecursiveGetFile(
        ICakeContext context,
        DirectoryPath directoryPath,
        string filter,
        Func<string, bool> predicate
        )
    {
        var directory = context.FileSystem.GetDirectory(context.MakeAbsolute(directoryPath));
        foreach(var file in directory.GetFiles(filter, SearchScope.Current))
        {
            yield return file.Path;
        }
        foreach(var file in directory.GetDirectories("*.*", SearchScope.Current)
            .Where(dir=>predicate(dir.Path.FullPath))
            .SelectMany(childDirectory=>RecursiveGetFile(context, childDirectory.Path, filter, predicate))
            )
        {
            yield return file;
        }
    }
