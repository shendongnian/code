        IEnumerable<string> EnumerateFiles(string folderPath, params string[] patterns)
        {
            return patterns.SelectMany(pattern => Directory.EnumerateFiles(folderPath, pattern));
        }
        void Later()
        {
            foreach (var file in EnumerateFiles(".", "*.config", "*.exe"))
            {
             // (code here)
            }
        }
    
