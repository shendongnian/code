    string startFolder = @"C:\MyFileFolder\";
        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(startFolder);
        IEnumerable<System.IO.FileInfo> fileList = dir.GetFiles("*.*",
        System.IO.SearchOption.AllDirectories);
        var fileData =
                from file in fileList
                where (file.Extension == ".dat" || file.Extension == ".csv")
            select GetFileData(file, ',')
    ;
    
    public  string GetFileData(string filesname, char sep)
        {
           using (StreamReader reader = new StreamReader(filesname))
           {
            var recs = (from line in reader.Lines(sep.ToString())
                let parts = line.Split(sep)
                 select       parts[2]);
            return recs
            }
        }
