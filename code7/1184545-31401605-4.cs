    string ZipFileToCreate = @"C:\Temp\Test.zip";
    string DirectoryToZip = @"C:\Temp\FolderToZip\";
    try
    {
      using (ZipFile zip = new ZipFile())
      {
        zip.StatusMessageTextWriter = System.Console.Out;
        zip.AddDirectory(DirectoryToZip); // recurses subdirectories
        zip.Save(ZipFileToCreate);
      }
    }
    catch (System.Exception ex1)
    {
      System.Console.Error.WriteLine("exception: " + ex1);
    }
