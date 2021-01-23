    private async Task<string> ReadText(string filePath)
    {
      using(FileStream sourceStream = new FileStream(filePath,
        FileMode.Open, FileAccess.Read, FileShare.Read,
        bufferSize:4096))
      {
        StringBuilder sb = new StringBuilder();
        byte[] buffer = new byte[0x1000];
        int numRead;
        while((numRead = await Task<int>.Factory.FromAsync(sourceStream.BeginRead, sourceStream.EndRead, buffer, 0, buffer.Length, null)) != 0)
        {
          sb.Append(Encoding.Unicode.GetString(buffer, 0, numRead);
        }
        return sb.ToString();
      }
    }
