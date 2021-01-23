    IEnumerable<string> SearchAccessibleFiles(string root, string searchTerm)
        {
            var files = new List<string>();
            foreach (var file in Directory.EnumerateFiles(root).Where(m => m.Contains(searchTerm)))
            {
                string extension = Path.GetExtension(file);
                files.Add(extension);
            }
            foreach (var subDir in Directory.EnumerateDirectories(root))
            {
                try
                {
                    files.AddRange(SearchAccessibleFiles(subDir, searchTerm));
                }
                catch (UnauthorizedAccessException ex)
                {
                    // ...
                }
            }
            return files.Distinct().ToList();
        }
