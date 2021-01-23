    IEnumerable<string> SearchAccessibleFiles(string root, string searchTerm)
    {
        return DirectoryUtils.EnumerateAccessibleFiles(rootPath, true)
            .Where(file => file.FullName.Contains(searchTerm))
            .Select(file => file.FullName);
    }
