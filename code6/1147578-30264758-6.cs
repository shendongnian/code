    private async Task<string> ReadText(string filePath)
    {
      using (FileStream sourceStream = new FileStream(filePath,
        FileMode.Open, FileAccess.Read, FileShare.Read,
        bufferSize: 4096))
        {
        using(var rdr = new StreamReader(sourceStream, Encoding.Unicode))
        {
          return await rdr.StreamReader.ReadToEndAsync();
        }
      }
    }
