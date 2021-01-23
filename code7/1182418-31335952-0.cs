    using (var memoryStream = new MemoryStream())
    {
       using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
       {
          var demoFile = archive.CreateEntry("foo.txt");
          using (var entryStream = demoFile.Open())
          using (var streamWriter = new StreamWriter(entryStream))
          {
             streamWriter.Write("Bar!");
          }
       }
       using (var fileStream = new FileStream(@"C:\Temp\test.zip", FileMode.Create))
       {
          memoryStream.Seek(0, SeekOrigin.Begin);
          memoryStream.CopyTo(fileStream);
       }
    }
