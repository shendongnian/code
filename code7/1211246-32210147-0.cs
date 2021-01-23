        /// <summary>
        /// Create zip archive from root directory using search patterns
        /// </summary>
        /// <param name="rootDirectory">Root directory</param>
        /// <param name="searchPatterns">Search patterns</param>
        /// <param name="zipFileName">Zip archive file name</param>
        public static void CreateZip(string rootDirectory, List<string> searchPatterns, string zipFileName)
        {
            var fileNames = GetFiles(rootDirectory, searchPatterns, true);
            CreateZipFromFiles(rootDirectory, zipFileName, fileNames);
        }
        private static IEnumerable<string> GetFiles(string rootDirectory, List<string> searchPatterns, bool includeSubdirectories)
        {
            var foundFiles = new List<string>();
            var directoriesToSearch = new Queue<string>();
            directoriesToSearch.Enqueue(rootDirectory);
            // Breadth-First Search
            while (directoriesToSearch.Count > 0)
            {
                var path = directoriesToSearch.Dequeue();
                foreach (var searchPattern in searchPatterns)
                {
                    foundFiles.AddRange(Directory.EnumerateFiles(path, searchPattern));
                }
                if (includeSubdirectories)
                {
                    foreach (var subDirectory in Directory.EnumerateDirectories(path))
                    {
                        directoriesToSearch.Enqueue(subDirectory);
                    }
                }
            }
            return foundFiles;
        }
        private static void CreateZipFromFiles(string rootDirectroy, string zipFileName, IEnumerable<string> fileNames)
        {
            var rootZipPath = Directory.GetParent(rootDirectroy).FullName;
            using (var zip = new ZipFile(zipFileName))
            {
                foreach (var filePath in fileNames)
                {
                    var directoryPathInArchive = Path.GetFullPath(Path.GetDirectoryName(filePath)).Substring(rootZipPath.Length);
                    zip.AddFile(filePath, directoryPathInArchive);
                }
                zip.Save();
            }
        }    
