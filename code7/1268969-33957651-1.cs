    int fileNameColumnOrdinal = reader.GetOrdinal("Filename");
    int fileLocationColumnOrdinal = reader.GetOrdinal("Filelocation");
    while (reader.Read())
    {
        string fileName = reader.GetString(fileNameColumnOrdinal);
        string fileLocation = reader.GetString(fileLocationColumnOrdinal);
        var a = new MyFiles
        {
           FileName = fileName,
           FileLocation = fileLocation,
           FullPath = System.IO.Path.Combine(fileLocation, fileName)
        };
       files.Add(a);
    }
