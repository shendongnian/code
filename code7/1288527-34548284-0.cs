    using (var tmp = new SevenZipExtractor(@"d:\Temp\7z465_extra.7z"))
    {
           for (int i = 0; i < tmp.ArchiveFileData.Count; i++)
           {
                 tmp.ExtractFiles(@"d:\Temp\Result\", tmp.ArchiveFileData[i].Index);
           }
    }
