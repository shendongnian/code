    public static IEnumerable<string> GetFiles(List<string> srcFiles)
    {
        var filePaths = new List<string>();
        using (var db = new ContentMgmtContext())
        {
            foreach (var fileInfo in srcFiles.Select(file => new FileInfo(file)))
            {
                var matches = db.Files.Where(o => o.FileName.ToLower() == fileInfo.Name.ToLower() ||
                    o.FileSize == fileInfo.Length.ToString())
                
                if (matches.Count() > 0)
                {
                    foreach (var match in matches)
                    {
                        Console.WriteLine("{0} already exist in DB", fileInfo.Name);
                        Console.WriteLine("Conflict file in DB is: {0}",match.FileName);
                    }
                }
                else
                {
                    filePaths.Add(fileInfo.FullName);
                }
            }
        }
        return filePaths;
    }
