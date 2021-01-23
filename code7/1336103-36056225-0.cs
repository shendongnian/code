    string SearchForFile(string searchPath, Func<string, bool> searchPredicate)
    {
        try
        {
            foreach (string fileName in Directory.EnumerateFiles(searchPath))
            {
                if (searchPredicate(fileName))
                {
                    return fileName;
                }
            }
            foreach (string dirName in Directory.EnumerateDirectories(searchPath))
            {
                var childResult = SearchForFile(dirName, searchPredicate);
                if (childResult != null)
                {
                    return childResult;
                }
            }
            return null;
        }
        catch (UnauthorizedAccessException)
        {
            return null;
        }
    }
