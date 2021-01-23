    var obj = new MovieListModel()
                {
                    FileName = fi.Name,
                    FilePathList = MapMyStrings(fi.prop1, fi.prop2),
                    Count = 1,
                    Extension = fi.Extension,
                    Size = Helper.FormatBytes(fi.Length),
                    CreatedTime = fi.CreationTime,
                    ModifiedTime = File.GetLastWriteTime(item)
                };
    List<string> MapMyStrings(params string[] objs){
         if(!objs.Length > 0) return null;
         return objs.ToList();
    }
