    var obj = new MovieListModel()
    {
        FileName = fi.Name,
        FilePathList = new List<string> { "Test", "Test1", fi.CreatedTime.ToString() /* use of .ToString() to convert other objects to string*/} /* and so on and so on */, 
        Count = 1,
        Extension = fi.Extension,
        Size = Helper.FormatBytes(fi.Length),
        CreatedTime = fi.CreationTime,
        ModifiedTime = File.GetLastWriteTime(item)
    };
    movieList.Add(obj);
