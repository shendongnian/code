    public static class Program
    {
        public static void Main()
        {
            var directoryPaths = new List<string>
                {
                    @"C:\root\path_1",
                    @"C:\root\path_2",
                    @"C:\root\path_3"
                    // …
                };
            var acceptedExtensions = new List<string>
                {
                    ".jpg",
                    ".gif"
                };
            
            var filePaths = directoryPaths
                .SelectMany(directoryPath =>
                    EnumerateFiles(directoryPath, acceptedExtensions, SearchOption.AllDirectories))
                .ToList()
                .AsReadOnly();
            // …
        }
        private static IEnumerable<string> EnumerateFiles(
            string path,
            IEnumerable<string> searchPatterns,
            SearchOption searchOption)
        {
            var filePaths = searchPatterns.SelectMany(
                searchPattern => Directory.EnumerateFiles(path, searchPattern, searchOption));
            return filePaths;
        }
    }
