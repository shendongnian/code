    using ICSharpCode.SharpZipLib.GZip;
    using ICSharpCode.SharpZipLib.Tar;
    
    public void ExtractTGZ(String gzArchiveName, String destFolder)
    {
        Stream inStream = File.OpenRead(gzArchiveName);
        Stream gzipStream = new GZipInputStream(inStream);
    
        TarArchive tarArchive = TarArchive.CreateInputTarArchive(gzipStream);
        tarArchive.ExtractContents(destFolder);
        tarArchive.Close();
    
        gzipStream.Close();
        inStream.Close();
    }
