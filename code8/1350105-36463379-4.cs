        static IEnumerable<FileInfo> GetAllFilesRecursive(string path)
        {
            var di = new DirectoryInfo(path);
            var files = new List<FileInfo>();
            files.AddRange(di.GetFiles("."));
            foreach (var directory in Directory.GetDirectories(path))
            {
                try
                {
                    files.AddRange(GetAllFilesRecursive(directory));
                }
                catch (UnauthorizedAccessException) // ignore directories which the user does not have access to
                {}
                
            }
            return files;
        }
