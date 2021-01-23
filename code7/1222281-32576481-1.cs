    var readmeEntry = archive.CreateEntry(cFileToBackup);
    using (var fsData = new FileStream(cFileFull, FileMode.Open, FileAccess.Read))
    using (var writer = new BinaryWriter(readmeEntry.Open()))
    {
        var buffer = new byte[1024];
        int bytesRead;
        while ((bytesRead = fsData.Read(buffer, 0, buffer.Length)) > 0)
        {
             writer.Write(buffer, 0, bytesRead); // here it fails
             writer.Flush();
        }
    }
