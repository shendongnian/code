    public IZipFileWrapper
    {
         ZipArchive OpenRead(string fileName)
    }
    
    public ZipFileWrapper : IZipFileWrapper
    {
       public ZipArchive OpenRead(string fileName)
       {
         return ZipFile.OpenRead(fileName)
       }
    }
