    private void Extract()
    {
        //Zip Location
        string zipToUnpack = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ABCD.zip";
        // .EXE Directory
        string unpackDirectory = System.IO.Path.GetDirectoryName(
            System.Reflection.Assembly.GetExecutingAssembly().Location);
        using (ZipFile zip = ZipFile.Read(zipToUnpack))
        {
            foreach (ZipEntry e in zip)
            {
                 //If filename matches
                 if (e.FileName == "ab.dat" || e.FileName == "cd.dat")
                     e.Extract(unpackDirectory, ExtractExistingFileAction.OverwriteSilently);
            }
        }
    }
