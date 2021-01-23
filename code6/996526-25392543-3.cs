    private static List<FileMeta> EnsureUniqueFileNames(IEnumerable<FileMeta> fileMetas)
    {
        var returnedList = new List<FileMeta>();
        foreach (var file in fileMetas)
        {
            int count = 0;
            string originalFileName = file.FileName;
            while (returnedList.Any(fileMeta => fileMeta.FileName.Equals(file.FileName, 
                                                StringComparison.OrdinalIgnoreCase))
            {
                string fileNameOnly = Path.GetFileNameWithoutExtension(originalFileName);
                string extension = Path.GetExtension(file.FileName);
                file.FileName = string.Format("{0}({1}){2}", fileNameOnly, count, extension);
                count++;
            }
    
            returnList.Add(file);
        }
        return returnList;
    }
