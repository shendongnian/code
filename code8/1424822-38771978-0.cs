    public static class Program
    {
        public static void Main()
        {
            var directoryPaths = new List<string>
                {
                    @"C:\path_1",
                    @"C:\path_2",
                    @"C:\path_3"
                    // …
                };
            var acceptedExtensions = new HashSet<string>
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
