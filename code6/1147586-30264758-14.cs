    private async Task WriteTextAsync(string filePath, string text)
    {
      byte[] encodedText = Encoding.Unicode.GetBytes(text);
      using (FileStream sourceStream = new FileStream(filePath,
        FileMode.Create, FileAccess.Write, FileShare.None, 
        bufferSize: 4096, useAsync: true))
      {
        await Task.Factory.FromAsync(sourceStream.BeginWrite, sourceStream.EndWrite, encodedText, 0, encodedText.Length, null);
      }
    }
