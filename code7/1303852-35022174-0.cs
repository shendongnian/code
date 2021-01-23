    public static System.Net.Mail.Attachment CreateZipAttachmentFromString(string content, string filename)
    {
      using (MemoryStream memoryStream = new MemoryStream())
      {
        using (ZipArchive zipArchive = new ZipArchive(memoryStream, ZipArchiveMode.Update))
        {
          ZipArchiveEntry zipArchiveEntry = zipArchive.CreateEntry(filename);
          using (StreamWriter streamWriter = new StreamWriter(zipArchiveEntry.Open()))
          {
            streamWriter.Write(content);
          }
    
        }
    
        memoryStream.Position = 0;
    
        return new Attachment(memoryStream, filename + ".zip", MediaTypeNames.Application.Zip);
      }
    }
