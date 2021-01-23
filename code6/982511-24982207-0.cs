    private void Extract()
    {
        string zipToUnpack = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ABCD.zip";
        string unpackDirectory = "Extracted Files";
        using (ZipFile zip1 = ZipFile.Read(zipToUnpack))
        {
            foreach (ZipEntry e in zip1)
            {
                 if (e.FileName == "ab.dat" || e.FileName == "cd.dat")
                     e.Extract(unpackDirectory, ExtractExistingFileAction.OverwriteSilently);
            }
         }
      }
